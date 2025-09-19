//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       ITask.cs
//  Desciption: 
//
//  (c) , 2025
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
        // Attributes
        DateTime? Start { get; set; }
        DateTime? End { get; set; }
        #endregion

        #region Related Entities
        IContract Contract { get; }
        IService Service { get; }
        ILocation OccursAt { get; }
        IList<ITask> Children { get; }
        #endregion

        #region Operations
        #endregion
    }
}