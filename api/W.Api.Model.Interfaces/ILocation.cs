//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       ILocation.cs
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
    public interface ILocation : IModelObject
    {
        #region Attributes
        // Attributes
        #endregion

        #region Related Entities
        ITimeZone TimeZone { get; }
        IJurisdiction GovernedBy { get; }
        #endregion

        #region Operations
        #endregion
    }
}