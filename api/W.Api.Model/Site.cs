//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Site.cs
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
    /// Site Model Object
    /// </summary>
    public class Site : ModelObject, ISite
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Site" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Site (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int OperatedBy__OrganisationId { get; set; }

        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Gets the Organisation for this Site
        /// </summary>
        public IOrganisation OperatedBy
        {
            get {
                return Manager
                    .RepositoryFor<IOrganisation> (ClaimsSubject)
                    .Read (OperatedBy__OrganisationId);
            }
        }

        /// <summary>
        /// Get Locations for this Site
        /// </summary>
        public IList<ILocation> Locations
        {
            get {
                // TODO
                return Manager
                    .RepositoryFor<ILocation> (ClaimsSubject)
                    .ReadWhere (
                        $"TODO = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}