//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IContract.cs
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
    public interface IContract : IModelObject
    {
        #region Attributes
        // Related Entities
        int TenancyId { get; set; }
        int Client__OrganisationId { get; set; }

        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        ITenancy Tenancy { get; }
        IOrganisation Client { get; }
        IList<ITask> Tasks { get; }
        IList<IService> Services { get; }
        #endregion

        #region Operations
        #endregion
    }
}