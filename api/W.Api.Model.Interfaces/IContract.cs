//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IContract.cs
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
    public interface IContract : IModelObject
    {
        #region Attributes
        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        IClient With { get; }
        IList<ITask> Tasks { get; }
        #endregion

        #region Operations
        #endregion
    }
}