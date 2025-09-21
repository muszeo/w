//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IResource.cs
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
    public interface IResource : IModelObject
    {
        #region Attributes
        // Related Entities
        int TenancyId { get; set; }
        int BasedAt__LocationId { get; set; }

        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        ITenancy Tenancy { get; }
        ILocation BasedAt { get; }
        #endregion

        #region Operations
        #endregion
    }
}