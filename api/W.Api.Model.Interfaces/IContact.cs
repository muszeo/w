//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IContact.cs
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
    public interface IContact : IModelObject
    {
        #region Attributes
        // Related Entities
        int OrganisationId { get; set; }

        // Attributes
        #endregion

        #region Related Entities
        IOrganisation Organisation { get; }
        #endregion

        #region Operations
        #endregion
    }
}