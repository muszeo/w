//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ITenancy.cs
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
    public interface ITenancy : IModelObject
    {
        #region Attributes
        // Attributes
        Guid Identifier { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        #endregion

        #region Operations
        #endregion
    }
}