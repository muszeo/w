//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IService.cs
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
    public interface IService : IModelObject
    {
        #region Attributes
        // Related Entities
        int CatalogueId { get; set; }

        // Attributes
        #endregion

        #region Related Entities
        ICatalogue Catalogue { get; }
        #endregion

        #region Operations
        #endregion
    }
}