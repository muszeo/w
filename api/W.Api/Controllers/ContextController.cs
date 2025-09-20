//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ContextController.cs
//  Desciption: ContextController WebAPI
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System.Xml.Linq;
using System.Windows.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using W.Api.Dtos;
using W.Api.Model;
using W.Api.Logging;
using W.Api.Dtos.Lists;
using W.Api.Exceptions;
using W.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using W.Api.Authorisation;
using W.Api.Dtos.Builders;
using W.Api.Model.Interfaces;
using W.Api.Repository.Configured;
using static W.Api.Settings.Constants.Events;
#endregion

namespace W.Api.Controllers
{
    /// <summary>
    /// ContextController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class ContextController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ContextController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public ContextController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region GETs
        /// <summary>
        /// Gets a Context using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/context/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// ContextDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<ContextDto> Get (int id)
        {
            Logger.Debug ($"Calling Group -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    ContextDto _rtn = new ContextDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Context Item.
                    ILocation _c =
                        Manager ()
                            .RepositoryFor<ILocation> (Subject)
                            .Read (id);

                    // Create return
                    if (_c != null) {

                        // Pull default 'QueueFor' period (milliseconds) for this environment.
                        // NB. The QueueFor instructs the client-side consumer script how long
                        // (in milliseconds) posted Metric Observations should be queued for before
                        // being sent in batches.
                        SettingsModel? _s =
                            RepositoryFactory
                                .RepositoryFor<SettingsModel> ()
                                .Get ()
                                .FirstOrDefault ();

                        // Return Context
                        if (_s != null) {
                            _rtn = _rtn.From (_c, _s.QueueFor, _s.AutoObserve);
                        }

                    } else {
                        throw new EntityNotFoundException ("Context", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Context.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>ContextDto</returns>
        [HttpPost]
        public ActionResult<ContextDto> Post ([FromBody] NewContextDto dto)
        {
            Logger.Debug ($"Calling Group -> Post New *Identity Context* - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    ContextDto _rtn = new ContextDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Context for SubjectIdentifier '{Subject.Identifier}' and Provider '{Subject.Provider}'"
                            );

                            // Create new Context
                            // NB. We use the SubjectIdentifier and Provider from the access_token provided in the call to this method.
                            ILocation _i = new IdentityContext (Manager (), Subject) {
                                Start = dto.Start,
                                End = dto.End,
                                SubjectIdentifier = Subject.Identifier,
                                Provider = Subject.Provider,
                                Username = Subject.Username,
                                Email = Subject.Email,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Context
                            Manager ()
                                .RepositoryFor<ILocation> (Subject)
                                .Upsert (_i, trans);

                            // Pull default 'QueueFor' (in milliseconds) for this environment.
                            //  NB. The QueueFor instructs the client-side consumer script how long
                            //  (in milliseconds) posted Metric Observations should be queued for before
                            //  being sent in batches.
                            // Pull Auto-Observe Metrics for this Environment.
                            SettingsModel? _s =
                                RepositoryFactory
                                    .RepositoryFor<SettingsModel> ()
                                    .Get ()
                                    .FirstOrDefault ();

                            // Return new Context
                            if (_s != null) {
                                _rtn = _rtn.From (_i, _s.QueueFor, _s.AutoObserve);
                            }

                        }
                    );

                    return _rtn;

                }
            );
        }
        #endregion

        #region PUTs
        #endregion

        #region DELETEs
        #endregion
    }
}