//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       LocationController.cs
//  Desciption: LocationController WebAPI
//
//  Domain:
//  - Location
//  - TimeZone
//  - Jurisdiction
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
    /// LocationController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class LocationController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="LocationController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public LocationController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region >>>> Locations
        #region GETs
        /// <summary>
        /// Gets a Location using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/location/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// LocationDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<LocationDto> Get (int id)
        {
            Logger.Debug ($"Calling Location -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    LocationDto _rtn = new LocationDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Location Item.
                    ILocation _t =
                        Manager ()
                            .RepositoryFor<ILocation> (Subject)
                            .Read (id);

                    // Create return
                    if (_t != null) {

                        _rtn = _rtn.From (_t);

                    } else {
                        throw new EntityNotFoundException ("Location", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Location.
        ///
        /// verb:       POST
        /// method:     /api/location
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>LocationDto</returns>
        [HttpPost]
        public ActionResult<LocationDto> Post ([FromBody] NewLocationDto dto)
        {
            Logger.Debug ($"Calling Location -> Post New Location - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    LocationDto _rtn = new LocationDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Location for SubjectIdentifier '{Subject.Identifier}' and Provider '{Subject.Provider}'"
                            );

                            // Create new Location
                            ILocation _c = new Location (Manager (), Subject) {

                                // Related Entities
                                TimeZoneId = dto.TimeZoneId,
                                GovernedBy__JurisdictionId = dto.GovernedBy__JurisdictionId,

                                // Attributes

                                // Audit
                                CreatedOn = DateTime.Now
                            };

                            // Save new Location
                            Manager ()
                                .RepositoryFor<ILocation> (Subject)
                                .Upsert (_c, trans);

                            // Return new Location
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

        #region >>>> >>>> Jurisdiction
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