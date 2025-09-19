//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IAllocation.cs
//  Desciption: 
//
//  (c) , 2025
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