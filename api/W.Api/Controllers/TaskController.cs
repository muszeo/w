//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       TaskController.cs
//  Desciption: TaskController WebAPI
//
//  Domain:
//  - Task
//  - Allocation (of Resource(s) to Task)
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using W.Api.Dtos;
using W.Api.Model;
using W.Api.Logging;
using W.Api.Dtos.Lists;
using W.Api.Exceptions;
using W.Api.Repository;
using W.Api.Authorisation;
using W.Api.Dtos.Builders;
using W.Api.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using W.Api.Repository.Configured;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
#endregion

namespace W.Api.Controllers
{
    /// <summary>
    /// TaskController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class TaskController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="TaskController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public TaskController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region >>>> Tasks
        #region GETs
        /// <summary>
        /// Gets a Task using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/Task/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// TaskDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<TaskDto> Get (int id)
        {
            Logger.Debug ($"Calling Task -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    TaskDto _rtn = new TaskDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Task Item.
                    ITask _t =
                        Manager ()
                            .RepositoryFor<ITask> (Subject)
                            .Read (id);

                    // Create return
                    if (_t != null) {

                        _rtn = _rtn.From (_t);

                    } else {
                        throw new EntityNotFoundException ("Task", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Task.
        ///
        /// verb:       POST
        /// method:     /api/Task
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>TaskDto</returns>
        [HttpPost]
        public ActionResult<TaskDto> Post ([FromBody] NewTaskDto dto)
        {
            Logger.Debug ($"Calling Task -> Post New Task - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    TaskDto _rtn = new TaskDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Task for SubjectIdentifier '{Subject.Identifier}' and Provider '{Subject.Provider}'"
                            );

                            // Create new Task
                            ITask _c = new Model.Task (Manager (), Subject) {

                                // Related Entities
                                ServiceId = dto.ServiceId,
                                ContractId = dto.ContractId,
                                Parent__TaskId = dto.Parent__TaskId,
                                OccursAt__LocationId = dto.OccursAt__LocationId,

                                // Attributes               
                                Start = dto.Start,
                                End = dto.End,

                                // Audit
                                CreatedOn = DateTime.Now
                            };

                            // Save new Task
                            Manager ()
                                .RepositoryFor<ITask> (Subject)
                                .Upsert (_c, trans);

                            // Return new Task
                            _rtn = _rtn.From (_c);

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

        #region >>>> >>>> Allocations
        #region GETs
        #endregion

        #region POSTs
        #endregion

        #region PUTs
        #endregion

        #region DELETEs
        #endregion
        #endregion
        #endregion
    }
}