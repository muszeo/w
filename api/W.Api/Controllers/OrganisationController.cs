//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       OrganisationController.cs
//  Desciption: OrganisationController WebAPI
//
//  Domain:
//  - Organisation
//  - Site
//  - Contacts
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
    /// OrganisationController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class OrganisationController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="OrganisationController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public OrganisationController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region >>>> Organisations
        #region GETs
        /// <summary>
        /// Gets a Organisation using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/organisation/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// OrganisationDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<OrganisationDto> Get (int id)
        {
            Logger.Debug ($"Calling Organisation -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    OrganisationDto _rtn = new OrganisationDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Organisation Item.
                    IOrganisation _o =
                        Manager ()
                            .RepositoryFor<IOrganisation> (Subject)
                            .Read (id);

                    // Create return
                    if (_o != null) {

                        _rtn = _rtn.From (_o);

                    } else {
                        throw new EntityNotFoundException ("Organisation", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Organisation.
        ///
        /// verb:       POST
        /// method:     /api/Organisation
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>OrganisationDto</returns>
        [HttpPost]
        public ActionResult<OrganisationDto> Post ([FromBody] NewOrganisationDto dto)
        {
            Logger.Debug ($"Calling Organisation -> Post New Organisation - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    OrganisationDto _rtn = new OrganisationDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Organisation for SubjectIdentifier '{Subject.Identifier}' and Provider '{Subject.Provider}'"
                            );

                            // Create new Organisation
                            // NB. We use the SubjectIdentifier and Provider from the access_token provided in the call to this method.
                            IOrganisation _c = new Organisation (Manager (), Subject) {
                                Name = dto.Name,
                                Description = dto.Description,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Organisation
                            Manager ()
                                .RepositoryFor<IOrganisation> (Subject)
                                .Upsert (_c, trans);

                            // Return new Organisation
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

        #region >>>> Sites
        #region GETs
        #endregion

        #region POSTs
        #endregion

        #region PUTs
        #endregion

        #region DELETEs
        #endregion
        #endregion

        #region >>>> >>>> Contacts
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