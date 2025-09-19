//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IResourceContact.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
#endregion

namespace W.Api.Model.Interfaces
{
    public interface IResourceContact : IModelObject
    {
        #region Attributes
        // Attributes
        #endregion

        #region Related Entities
        IResource Resource { get; }
        IContact Contact { get; }
        #endregion

        #region Operations
        #endregion
    }
}