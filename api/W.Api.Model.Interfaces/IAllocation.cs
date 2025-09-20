//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IAllocation.cs
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
    public interface IAllocation : IModelObject
    {
        #region Attributes
        // Related Entities
        int TaskId { get; set; }
        int ResourceId { get; set; }

        // Attributes
        #endregion

        #region Related Entities
        ITask Task { get; }
        IResource Resource { get; }
        #endregion

        #region Operations
        #endregion
    }
}