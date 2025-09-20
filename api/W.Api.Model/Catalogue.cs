//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Catalogue.cs
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
    /// Catalogue Model Object
    /// </summary>
    public class Catalogue : ModelObject, ICatalogue
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Catalogue" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Catalogue (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Get Services for this Catalogue
        /// </summary>
        public IList<IService> Services
        {
            get {
                return Manager
                    .RepositoryFor<IService> (ClaimsSubject)
                    .ReadWhere (
                        $"CatalogueId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}