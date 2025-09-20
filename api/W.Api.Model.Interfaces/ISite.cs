//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ISite.cs
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
    public interface ISite : IModelObject
    {
        #region Attributes
        // Related Entities
        int OperatedBy__OrganisationId { get; set; }

        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        IOrganisation OperatedBy { get; }
        IList<ILocation> Locations { get; }
        #endregion

        #region Operations
        #endregion
    }
}