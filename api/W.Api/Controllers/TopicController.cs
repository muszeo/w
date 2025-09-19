//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       TopicController.cs
//  Desciption: TopicController WebAPI
//
//  (c) , 2025
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
    /// TopicController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class TopicController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="TopicController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public TopicController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region GETs
        /// <summary>
        /// Gets a Metric Topic using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/topic/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// TopicDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<TopicDto> Get (int id)
        {
            Logger.Debug ($"Calling Topic -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    TopicDto _rtn = new TopicDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Topic Item.
                    IContract _t =
                        Manager ()
                            .RepositoryFor<IContract> (Subject)
                            .Read (id);

                    // Create return
                    if (_t != null) {
                        _rtn = _rtn.From (_t);
                    } else {
                        throw new EntityNotFoundException ("Topic", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Metric Topic.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>TopicDto</returns>
        [HttpPost]
        public ActionResult<TopicDto> Post ([FromBody] NewTopicDto dto)
        {
            Logger.Debug ($"Calling Topic -> Post New Metric *Topic* - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    TopicDto _rtn = new TopicDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Topic '{dto.Name}'"
                            );

                            // Create new Topic
                            IContract _t = new Topic (Manager (), Subject) {
                                Name = dto.Name,
                                Description = dto.Description,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Topic
                            Manager ()
                                .RepositoryFor<IContract> (Subject)
                                .Upsert (_t, trans);

                            // Return new Topic
                            _rtn = _rtn.From (_t);
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