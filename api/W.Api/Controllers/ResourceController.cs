//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ResourceController.cs
//  Desciption: ResourceController WebAPI
//
//  Domain:
//  - Resource
//      - Fixed
//      - Mobile
//      - Worker
//      - Consumable
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
    /// ResourceController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class ResourceController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ResourceController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public ResourceController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region GETs
        /// <summary>
        /// Gets a Resource using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/resource/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// ResourceDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<ResourceDto> Get (int id)
        {
            Logger.Debug ($"Calling Resource -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    ResourceDto _rtn = new ResourceDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Resource Item.
                    IResource _r =
                        Manager ()
                            .RepositoryFor<IResource> (Subject)
                            .Read (id);

                    // Create return
                    if (_r != null) {

                        _rtn = _rtn.From (_r);

                    } else {
                        throw new EntityNotFoundException ("Resource", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Resource.
        ///
        /// verb:       POST
        /// method:     /api/resource
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>ResourceDto</returns>
        [HttpPost]
        public ActionResult<ResourceDto> Post ([FromBody] NewResourceDto dto)
        {
            Logger.Debug ($"Calling Resource -> Post New Resource - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    ResourceDto _rtn = new ResourceDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Resource for SubjectIdentifier '{Subject.Identifier}' and Provider '{Subject.Provider}'"
                            );

                            // Create new Resource
                            // NB. We use the SubjectIdentifier and Provider from the access_token provided in the call to this method.
                            IResource _c = null;// = new Resource (Manager (), Subject) {
                            //     Name = dto.Name,
                            //     Description = dto.Description,
                            //     CreatedOn = DateTime.Now
                            // };

                            // Save new Resource
                            Manager ()
                                .RepositoryFor<IResource> (Subject)
                                .Upsert (_c, trans);

                            // Return new Resource
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
    }
}