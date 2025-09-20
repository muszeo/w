//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IClient.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Collections.Generic;
#endregion

namespace W.Api.Model.Interfaces
{
    public interface IClient : IModelObject
    {
        #region Attributes
        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        IList<IContact> Contacts {get; }
        IList<IContract> Contracts { get; }
        #endregion

        #region Operations
        #endregion
    }
}