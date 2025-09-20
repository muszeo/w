//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Organisation.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
using System.Collections.Generic;
#endregion

namespace W.Api.Model
{
    /// <summary>
    /// Organisation Model Object
    /// </summary>
    public class Organisation : ModelObject, IOrganisation
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Organisation" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Organisation (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int TimeZoneId { get; set; }
        public int Parent__OrganisationId { get; set; }

        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Gets this Organisations's TimeZone
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
        /// Gets this Organisation's Parent Organisation (if present, otherwise null)
        /// </summary>
        public IOrganisation Parent
        {
            get {
                return Manager
                    .RepositoryFor<IOrganisation> (ClaimsSubject)
                    .Read (Parent__OrganisationId);
            }
        }

        /// <summary>
        /// Gets this Organisation's Child Organisations (Subsidiaries, Departments, Depots etc.)
        /// </summary>
        public IList<IOrganisation> Children
        {
            get {
                return Manager
                    .RepositoryFor<IOrganisation> (ClaimsSubject)
                    .ReadWhere (
                        $"Parent__OrganisationId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}