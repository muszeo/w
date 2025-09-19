//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IClientContact.cs
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
    public interface IClientContact : IModelObject
    {
        #region Attributes
        // Attributes
        #endregion

        #region Related Entities
        IClient Client { get; }
        IContact Contact { get; }
        #endregion

        #region Operations
        #endregion
    }
}