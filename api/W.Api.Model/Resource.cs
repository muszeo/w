//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Resource.cs
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
    /// Resource Model Object
    /// </summary>
    public abstract class Resource : ModelObject, IResource
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Resource" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Resource (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int TenancyId { get; set; }
        public int BasedAt__LocationId { get; set; }

        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Gets the Tenancy for this Resource
        /// </summary>
        public ITenancy Tenancy
        {
            get {
                return Manager
                    .RepositoryFor<ITenancy> (ClaimsSubject)
                    .Read (TenancyId);
            }
        }

        /// <summary>
        /// Gets the BasedAt Location for this Resource
        /// </summary>
        public ILocation BasedAt
        {
            get {
                return Manager
                    .RepositoryFor<ILocation> (ClaimsSubject)
                    .Read (BasedAt__LocationId);
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}