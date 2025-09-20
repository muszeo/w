//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       SecurityManager.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

namespace W.Api.Authorisation
{
    public class SecurityManager : ISecurityManager
    {
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="SecurityManager" /> class.</summary>
        public SecurityManager ()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SecurityManager" /> class.</summary>
        /// <param name="authority">Authority (IDP).</param>
        /// <param name="exportClaims">Flag indicating whether to export claims to console or not.</param>
        public SecurityManager (string authority, bool exportClaims)
        {
            Authority = authority;
            ExportClaims = exportClaims;
        }
        #endregion

        #region Attributes
        public string Authority { get; set; }
        public bool ExportClaims { get; set; }
        #endregion
    }
}