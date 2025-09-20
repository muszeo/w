//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IModelObject.cs
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
    public interface IModelObject
    {
        #region Attributes
        int Id { get; set; }

        // Audit Attributes
        DateTime CreatedOn { get; set; }
        #endregion

        #region Operations
        #endregion
    }
}