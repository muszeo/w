//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IOrganisation.cs
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
    public interface IOrganisation : IModelObject
    {
        #region Attributes
        // Related Entities
        int TimeZoneId { get; set; }
        int Parent__OrganisationId { get; set; }

        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        ITimeZone TimeZone { get; }
        IOrganisation Parent { get; }
        IList<IOrganisation> Children { get; }
        #endregion

        #region Operations
        #endregion
    }
}