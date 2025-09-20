//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IClientContact.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
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
        // Related Entities
        int ClientId { get; set; }
        int ContactId { get; set; }

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