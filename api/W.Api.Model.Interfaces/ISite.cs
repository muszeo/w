//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       ISite.cs
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
    public interface ISite : IModelObject
    {
        #region Attributes
        // Attributes
        string Name { get; set; }
        string Description { get; set; }
        #endregion

        #region Related Entities
        IOrganisation OperatedBy { get; }
        IList<ILocation> Locations { get; }
        #endregion

        #region Operations
        #endregion
    }
}