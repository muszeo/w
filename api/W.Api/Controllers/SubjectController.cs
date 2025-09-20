//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       SubjectController.cs
//  Desciption: SubjectController WebAPI
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
    /// SubjectController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class SubjectController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="SubjectController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public SubjectController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region GETs
        /// <summary>
        /// Gets a Metric Subject using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/subject/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// SubjectDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<SubjectDto> Get (int id)
        {
            Logger.Debug ($"Calling Subject -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    SubjectDto _rtn = new SubjectDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Subject Item.
                    IResource _s =
                        Manager ()
                            .RepositoryFor<IResource> (Subject)
                            .Read (id);

                    // Create return
                    if (_s != null) {
                        _rtn = _rtn.From (_s);
                    } else {
                        throw new EntityNotFoundException ("Subject", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Metric Subject.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>SubjectDto</returns>
        [HttpPost]
        public ActionResult<SubjectDto> Post ([FromBody] NewSubjectDto dto)
        {
            Logger.Debug ($"Calling Subject -> Post New Metric *Subject* - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    SubjectDto _rtn = new SubjectDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Subject '{dto.Name}'"
                            );

                            // Create new Subject
                            IResource _s = new Subject (Manager (), Subject) {
                                Name = dto.Name,
                                Description = dto.Description,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Subject
                            Manager ()
                                .RepositoryFor<IResource> (Subject)
                                .Upsert (_s, trans);

                            // Return new Subject
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