//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ResourceContact.cs
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
    /// ResourceContact Model Object
    /// </summary>
    public class ResourceContact : ModelObject, IResourceContact
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ResourceContact" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public ResourceContact (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int ResourceId { get; set; }
        public int ContactId { get; set; }

        // Attributes
        #endregion

        #region Related Entities
        /// <summary>
        /// Gets this ResourceContact's Resource
        /// </summary>
        public IResource Resource
        {
            get {
                return Manager
                    .RepositoryFor<IResource> (ClaimsSubject)
                    .Read (ResourceId);
            }
        }

        /// <summary>
        /// Gets this ResourceContact's Contact
        /// </summary>
        public IContact Contact
        {
            get {
                return Manager
                    .RepositoryFor<IContact> (ClaimsSubject)
                    .Read (ContactId);
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}