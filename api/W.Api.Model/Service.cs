//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Service.cs
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
    /// Service Model Object
    /// </summary>
    public class Service : ModelObject, IService
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Service" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Service (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int CatalogueId { get; set; }

        // Attributes
        #endregion

        #region Related Entities
        /// <summary>
        /// Gets the Catalogue for this Service
        /// </summary>
        public ICatalogue Catalogue
        {
            get {
                return Manager
                    .RepositoryFor<ICatalogue> (ClaimsSubject)
                    .Read (CatalogueId);
            }
        }

        /// <summary>
        /// Gets the Tasks performances of this Service 
        /// </summary>
        public IList<ITask> Tasks
        {
            get {
                return Manager
                    .RepositoryFor<ITask> (ClaimsSubject)
                    .ReadWhere (
                        $"ServiceId = {Id}"
                    );
            }
        }

        /// <summary>
        /// Gets the Contracts that this Service appears in 
        /// </summary>
        public IList<IContract> Contracts
        {
            get {
                return Manager
                    .RepositoryFor<IContract> (ClaimsSubject)
                    .ReadWhere (
                        $"ServiceId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}