//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IOrganisation.cs
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
    public interface IOrganisation : IModelObject
    {
        #region Attributes
        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        ITimeZone TimeZone { get; }
        IList<IOrganisation> Children { get; }
        #endregion

        #region Operations
        #endregion
    }
}