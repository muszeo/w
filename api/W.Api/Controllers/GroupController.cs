//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       GroupController.cs
//  Desciption: GroupController WebAPI
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
    /// GroupController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class GroupController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="GroupController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public GroupController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region GETs
        /// <summary>
        /// Gets a Metric Group using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/group/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// GroupDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<GroupDto> Get (int id)
        {
            Logger.Debug ($"Calling Group -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    GroupDto _rtn = new GroupDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Group Item.
                    IClient _g =
                        Manager ()
                            .RepositoryFor<IClient> (Subject)
                            .Read (id);

                    // Create return
                    if (_g != null) {
                        _rtn = _rtn.From (_g);
                    } else {
                        throw new EntityNotFoundException ("Group", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Metric Group.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>GroupDto</returns>
        [HttpPost]
        public ActionResult<GroupDto> Post ([FromBody] NewGroupDto dto)
        {
            Logger.Debug ($"Calling Group -> Post New Metric *Group* - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    GroupDto _rtn = new GroupDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Group '{dto.Name}'"
                            );

                            // Create new Group
                            IClient _g = new Group (Manager (), Subject) {
                                Name = dto.Name,
                                Description = dto.Description,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Group
                            Manager ()
                                .RepositoryFor<IClient> (Subject)
                                .Upsert (_g, trans);

                            // Return new Group
                            _rtn = _rtn.From (_g);
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