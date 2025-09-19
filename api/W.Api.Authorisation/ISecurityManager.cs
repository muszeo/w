//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       ISecurityManager.cs
//  Desciption: 
//
//  (c) , 2025
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