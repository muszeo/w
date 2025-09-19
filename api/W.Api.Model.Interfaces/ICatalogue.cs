//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       ICatalogue.cs
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
    public interface ICatalogue : IModelObject
    {
        #region Attributes
        // Attributes
        #endregion

        #region Related Entities
        IList<IService> Services { get; }
        #endregion

        #region Operations
        #endregion
    }
}