//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Location.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Model
{
    /// <summary>
    /// Location Model Object
    /// </summary>
    public class Location : ModelObject, ILocation
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Location" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Location (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int TimeZoneId { get; set; }
        public int GovernedBy__JurisdictionId { get; set; }

        // Attributes
        #endregion

        #region Related Entities
        /// <summary>
        /// Gets this Locations's TimeZone
        /// </summary>
        public ITimeZone TimeZone
        {
            get {
                return Manager
                    .RepositoryFor<ITimeZone> (ClaimsSubject)
                    .Read (TimeZoneId);
            }
        }

        /// <summary>
        /// Gets this Location's governing Jurisdiction
        /// </summary>
        public IJurisdiction GovernedBy
        {
            get {
                return Manager
                    .RepositoryFor<IJurisdiction> (ClaimsSubject)
                    .Read (GovernedBy__JurisdictionId);
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}