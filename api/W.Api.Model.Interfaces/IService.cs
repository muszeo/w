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
using System.Collections.Generic;
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
        IList<ITask> Tasks { get; }
        IList<IContract> Contracts { get; }
        #endregion

        #region Operations
        #endregion
    }
}