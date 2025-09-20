//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ILocation.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
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
        // Related Entities
        public int TimeZoneId { get; set; }
        public int GovernedBy__JurisdictionId { get; set; }

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