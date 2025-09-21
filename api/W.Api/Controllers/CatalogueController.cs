//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       CatalogueController.cs
//  Desciption: CatalogueController WebAPI
//
//  Domain:
//  - Catalogue
//  - Service
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
    /// CatalogueController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class CatalogueController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="CatalogueController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public CatalogueController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region >>>> Catalogues
        #region GETs
        /// <summary>
        /// Gets a Catalogue using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/catalogue/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// CatalogueDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<CatalogueDto> Get (int id)
        {
            Logger.Debug ($"Calling Catalogue -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    CatalogueDto _rtn = new CatalogueDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Catalogue Item.
                    ICatalogue _c =
                        Manager ()
                            .RepositoryFor<ICatalogue> (Subject)
                            .Read (id);

                    // Create return
                    if (_c != null) {

                        _rtn = _rtn.From (_c);

                    } else {
                        throw new EntityNotFoundException ("Catalogue", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Catalogue.
        ///
        /// verb:       POST
        /// method:     /api/catalogue
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>CatalogueDto</returns>
        [HttpPost]
        public ActionResult<CatalogueDto> Post ([FromBody] NewCatalogueDto dto)
        {
            Logger.Debug ($"Calling Catalogue -> Post New Catalogue - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    CatalogueDto _rtn = new CatalogueDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Catalogue for SubjectIdentifier '{Subject.Identifier}' and Provider '{Subject.Provider}'"
                            );

                            // Create new Catalogue
                            // NB. We use the SubjectIdentifier and Provider from the access_token provided in the call to this method.
                            ICatalogue _c = new Catalogue (Manager (), Subject) {
                                Name = dto.Name,
                                Description = dto.Description,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Catalogue
                            Manager ()
                                .RepositoryFor<ICatalogue> (Subject)
                                .Upsert (_c, trans);

                            // Return new Catalogue
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

        #region >>>> >>>> Services
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