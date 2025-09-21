//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ICatalogue.cs
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
    public interface ICatalogue : IModelObject
    {
        #region Attributes
        // Related Entities
        int TenancyId { get; set; }

        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        IList<IService> Services { get; }
        #endregion

        #region Operations
        #endregion
    }
}