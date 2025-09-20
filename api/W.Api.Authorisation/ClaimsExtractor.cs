//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ClaimsExtractor.cs
//  Desciption: Extracts Subject Claims from ClaimsPrincipal.
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using W.Api.Logging;
using W.Api.Settings;
using System;
using System.Security;
using System.Security.Claims;
using System.Security.Permissions;
#endregion

namespace W.Api.Authorisation
{
    public struct ClaimsSubject
    {
        public string Identifier;
        public string Username;
        public string Email;
        public string Provider;
        public string [] Scopes;
    }

    public class ClaimsExtractor
    {
        /// <summary>
        /// Extracts Subject details (Identified, Username & Email) from the logged-on User's claims.
        /// </summary>
        public ClaimsSubject ExtractFrom (ClaimsPrincipal User, bool exportClaims = false)
        {
            // Subject Identifier
            Claim? _id = User.Claims.FirstOrDefault (
                _c => _c.Type.Equals (Constants.Security.Claims.IDENTIFIER)
            );

            // Name (Username)
            Claim? _name = User.Claims.FirstOrDefault (
                _c => _c.Type.Equals (Constants.Security.Claims.FQ_NAME)
            );
            if (_name == null) { // If fully-qualified name cannot be found, try common name.
                _name = User.Claims.FirstOrDefault (
                    _c => _c.Type.Equals (Constants.Security.Claims.NAME)
                );
            }

            // Email
            Claim? _email = User.Claims.FirstOrDefault (
                _c => _c.Type.Equals (Constants.Security.Claims.FQ_EMAIL)
            );
            if (_email == null) { // If fully-qualified email cannot be found, try common email.
                _email = User.Claims.FirstOrDefault (
                    _c => _c.Type.Equals (Constants.Security.Claims.EMAIL)
                );
            }

            // Provider
            Claim? _provider = User.Claims.FirstOrDefault (
                _c => _c.Type.Equals (Constants.Security.Claims.FQ_PROVIDER)
            );
            if (_provider == null) { // If fully-qualified provider cannot be found, try common provider.
                _provider = User.Claims.FirstOrDefault (
                    c => c.Type.Equals (Constants.Security.Claims.PROVIDER)
                );
            }

            // Scopes
            IEnumerable<Claim?> _scopeClaims = User.Claims.Where (
                _c => _c.Type.Equals (Constants.Security.Claims.SCOPE)
            );
            IList<string> _scopes = new List<string> ();
            if (_scopeClaims != null) {
                foreach (Claim? _c in _scopeClaims) {
                    _scopes.Add (_c.Value);
                }
            }

            if (_id == null || _name == null || _provider == null) {
                Logger.Warning (
                    $"Required 'id', 'name' and/or 'provider' Claim Not Found for Subject!"
                );
            }
#if DEBUG
            if (exportClaims || _id == null || _name == null || _provider == null) {
                Logger.Debug (
                    $"The following claims are available for the given Subject:"
                );
                foreach (Claim _c in User.Claims) {
                    Logger.Debug ($"'{_c.Type}' with value '{_c.Value}'");
                }
            }
#endif

            return new ClaimsSubject () {
                Identifier = (_id != null) ? _id.Value : string.Empty,
                Username = (_name != null) ? _name.Value : string.Empty,
                Email = (_email != null) ? _email.Value : string.Empty,
                Provider = (_provider != null) ? _provider.Value : string.Empty,
                Scopes = _scopes.ToArray ()
            };
        }
    }
}