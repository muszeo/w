//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ContractController.cs
//  Desciption: ContractController WebAPI
//
//  Domain:
//  - Contract
//  - Contracted Services
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
    /// ContractController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class ContractController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ContractController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public ContractController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region >>>> Contracts
        #region GETs
        /// <summary>
        /// Gets a Contract using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/contract/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// ContractDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<ContractDto> Get (int id)
        {
            Logger.Debug ($"Calling Contract -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    ContractDto _rtn = new ContractDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Contract Item.
                    IContract _c =
                        Manager ()
                            .RepositoryFor<IContract> (Subject)
                            .Read (id);

                    // Create return
                    if (_c != null) {

                        _rtn = _rtn.From (_c);

                    } else {
                        throw new EntityNotFoundException ("Contract", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Contract.
        ///
        /// verb:       POST
        /// method:     /api/Contract
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>ContractDto</returns>
        [HttpPost]
        public ActionResult<ContractDto> Post ([FromBody] NewContractDto dto)
        {
            Logger.Debug ($"Calling Contract -> Post New Contract - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectWriteScope ();
                    HasSubjectReadScope ();

                    ContractDto _rtn = new ContractDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Contract for SubjectIdentifier '{Subject.Identifier}' and Provider '{Subject.Provider}'"
                            );

                            // Create new Contract
                            // NB. We use the SubjectIdentifier and Provider from the access_token provided in the call to this method.
                            IContract _c = new Contract (Manager (), Subject) {
                                Name = dto.Name,
                                Description = dto.Description,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Contract
                            Manager ()
                                .RepositoryFor<IContract> (Subject)
                                .Upsert (_c, trans);

                            // Return new Contract
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
        #endregion
    }
}