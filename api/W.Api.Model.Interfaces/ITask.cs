//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ITask.cs
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
    public interface ITask : IModelObject
    {
        #region Attributes
        // Related Entities
        int ServiceId { get; set; }
        int ContractId { get; set; }
        int Parent__TaskId { get; set; }
        int OccursAt__LocationId { get; set; }

        // Attributes
        DateTime? End { get; set; }
        DateTime? Start { get; set; }
        #endregion

        #region Related Entities
        IService Service { get; }
        IContract Contract { get; }
        ILocation Location { get; }
        ITask Parent { get; }
        IList<ITask> Children { get; }
        #endregion

        #region Operations
        #endregion
    }
}