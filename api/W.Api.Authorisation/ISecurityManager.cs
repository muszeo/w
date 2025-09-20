//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ISecurityManager.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

namespace W.Api.Authorisation
{
    public interface ISecurityManager
    {
       #region Attributes 
        public bool ExportClaims { get; set; }
        #endregion
    }
}