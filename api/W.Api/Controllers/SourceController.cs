//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       SourceController.cs
//  Desciption: SourceController WebAPI
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
using static W.Api.Settings.Constants.Events;
#endregion

namespace W.Api.Controllers
{
    /// <summary>
    /// SourceController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class SourceController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="SourceController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public SourceController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region GETs
        /// <summary>
        /// Gets a Metric Source using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/source/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// SourceDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<SourceDto> Get (int id)
        {
            Logger.Debug ($"Calling Source -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    SourceDto _rtn = new SourceDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Source Item.
                    IOrganisation _s =
                        Manager ()
                            .RepositoryFor<IOrganisation> (Subject)
                            .Read (id);

                    // Create return
                    if (_s != null) {
                        _rtn = _rtn.From (_s);
                    } else {
                        throw new EntityNotFoundException ("Source", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Metric Source.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>SourceDto</returns>
        [HttpPost]
        public ActionResult<SourceDto> Post ([FromBody] NewSourceDto dto)
        {
            Logger.Debug ($"Calling Source -> Post New Metric *Source* - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    SourceDto _rtn = new SourceDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Source '{dto.Name}'"
                            );

                            // Create new Source
                            IOrganisation _s = new Source (Manager (), Subject) {
                                Name = dto.Name,
                                Description = dto.Description,
                                Type = dto.Type,
                                Code = dto.Code,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Source
                            Manager ()
                                .RepositoryFor<IOrganisation> (Subject)
                                .Upsert (_s, trans);

                            // Return new Source
                            _rtn = _rtn.From (_s);
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