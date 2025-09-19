//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       AbstractWebApiController.cs
//  Desciption: Base controller for WebApi
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using W.Api.Logging;
using W.Api.Settings;
using W.Api.Exceptions;
using W.Api.Repository;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
using Microsoft.AspNetCore.Authorization;
#endregion

namespace W.Api.Controllers
{
    /// <summary>
    ///   Abstact (base) Controller WebAPI
    /// </summary>
    public abstract class AbstractWebApiController : ControllerBase
    {
        #region Private Member Variables
        private IModelManager? theManager;
        private ClaimsSubject theSubject;
        #endregion

        #region Protected Member Variables        
        /// <summary>
        /// The database manager
        /// </summary>
        protected DatabaseManager theDatabaseRepo;
        protected bool theExportClaims = false;
        protected string theClaimsAuthority;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="AbstractWebApiController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="securityManager">The security configuration.</param>
        /// <exception cref="W.Api.Exceptions.DataSourceConnectionException">Failed to open connection</exception>
        public AbstractWebApiController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> securityManager)
        {
            // uri arrives via Dependency Injection.
            theDatabaseRepo = databaseRepository.Value;
            theExportClaims = securityManager.Value.ExportClaims;
            theClaimsAuthority = securityManager.Value.Authority;
        }
        #endregion

        #region Public Operations
        #endregion

        #region Protected Operations
        /// <summary>
        /// Executes an Action (void return function) and wraps exception handling for HTTP.
        /// </summary>
        /// <param name="action">The function to invoke.</param>
        protected ActionResult ExecuteHttp (Action action)
        {
            ActionResult _rtn;
            try {

                // Execute function.
                action ();
                _rtn = Ok ();

                // Catch Exceptions and turn them into Http Status Codes.
            } catch (EntityNotFoundException __x) {
                Logger.Error (__x);
                _rtn = NotFound (__x.Message);
            } catch (EntityReferenceNullException __x) {
                Logger.Error (__x);
                _rtn = NotFound (__x.Message);
            } catch (EntityAlreadyExistsException __x) {
                Logger.Error (__x);
                _rtn = Conflict (__x.Message);
            } catch (BusinessRuleException __x) {
                Logger.Error (__x);
                _rtn = BadRequest (__x.Message);
            } catch (BusinessAuthorisationException __x) {
                Logger.Error (__x);
                _rtn = Unauthorized (__x.Message);
            } catch (Exception __x) {
                Logger.Error (__x);
                _rtn = Problem (detail: __x.Message, statusCode: StatusCodes.Status500InternalServerError);
            } finally {
                Manager ()
                    .Close ();
            }
            return _rtn;
        }

        /// <summary>
        /// Executes an Func (non-void return function) and wraps exception handling for HTTP.
        /// </summary>
        /// <returns>The HTTP Response.</returns>
        /// <param name="action">The function to invoke.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected ActionResult<T> ExecuteHttp<T> (Func<T> action)
        {
            ActionResult<T> _rtn = default (T);
            try {
                // Execute function.
                _rtn = action ();

                // If null need to raise a 404 not found.
                if (_rtn == null) {
                    _rtn = NotFound ();
                }

                // Catch Exceptions and turn them into Http Status Codes.
            } catch (EntityNotFoundException __x) {
                Logger.Error (__x);
                _rtn = NotFound (__x.Message);
            } catch (EntityReferenceNullException __x) {
                Logger.Error (__x);
                _rtn = NotFound (__x.Message);
            } catch (EntityAlreadyExistsException __x) {
                Logger.Error (__x);
                _rtn = Conflict (__x.Message);
            } catch (BusinessRuleException __x) {
                Logger.Error (__x);
                _rtn = BadRequest (__x.Message);
            } catch (BusinessAuthorisationException __x) {
                Logger.Error (__x);
                _rtn = Unauthorized (__x.Message);
            } catch (Exception __x) {
                Logger.Error (__x);
                _rtn = Problem (
                    detail: __x.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            } finally {
                Manager ()
                    .Close ();
            }
            return _rtn;
        }

        /// <summary>
        /// Factory method to create or return existing Repository Manager.
        /// </summary>
        /// <returns></returns>
        protected IModelManager Manager ()
        {
            if (theManager == null) {
                theManager =
                    new RepositoryManager (
                        theDatabaseRepo.Name,
                        theDatabaseRepo.ConnectionString
                    );
                theManager.Open ();
            }
            return theManager;
        }

        /// <summary>
        /// Extracts Subject details (Identified, Username & Email) from the logged-on User's claims.
        /// </summary>
        protected ClaimsSubject Subject
        {
            get {
                if (theSubject.Identifier == null ||  theSubject.Identifier.Length == 0) {
                    theSubject = new ClaimsExtractor ()
                        .ExtractFrom (User, theExportClaims);
                }
                return theSubject;
            }
        }

        /// <summary>
        /// Extracts a unique Cache Key for the current Subject.
        /// </summary>
        protected string CacheKey
        {
            get {
                return $"{Subject.Provider}:{Subject.Identifier}";
            }
        }

        /// <summary>
        /// Checks the logged-on Subject to see if they have the required '{context}Api.read' scope.
        /// NB. Context defaults to "invoicing" for this first version of the API. In future we will remove this default
        /// and force callers to specify a context.
        /// </summary>
        /// <param name="context">Scope Context.</param>
        protected void HasSubjectReadScope (string context = "metric")
        {
            __CheckSubjectScope (
                $"{context}{Constants.Security.Scopes.API}{Constants.Security.Scopes.READ}"
            );
        }

        /// <summary>
        /// Checks the logged-on Subject to see if they have the '{context}Api.write' scope.
        /// NB. Context defaults to "invoicing" for this first version of the API. In future we will remove this default
        /// and force callers to specify a context.
        /// </summary>
        /// <param name="context">Scope Context.</param>
        protected void HasSubjectWriteScope (string context = "metric")
        {
            __CheckSubjectScope (
                $"{context}{Constants.Security.Scopes.API}{Constants.Security.Scopes.WRITE}"
            );
        }

        /// <summary>
        /// Decodes data from a Business Event's data field so that it is usable internally
        /// to this service.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected string Decode (string text)
        {
            return text.Replace ("&quot;", "\"");
        }
        #endregion

        #region Private Operations
        /// <summary>
        /// Checks the logged-on Subject to see if they have relevant 'Scope'
        /// Claims that allow them to access this API, i.e. "eventingApi.read" and "eventingApi.write".
        /// </summary>
        /// <param name="requiredScope">Required Scope to check for</param>
        /// <exception cref="BusinessAuthorisationException" />
        private void __CheckSubjectScope (string requiredScope)
        {
            if (!Subject.Scopes.Contains (requiredScope)) {
                throw new BusinessAuthorisationException (
                    $"Subject '{Subject.Username}' from Provider '{Subject.Provider}' does not have appropriate scope to access this API. " +
                    $"Required scope '{requiredScope}' is missing from their Claims."
                );
            }
        }
        #endregion
    }
}