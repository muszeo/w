//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Contact.cs
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
    /// Contact Model Object
    /// </summary>
    public class Contact : ModelObject, IContact
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Contact" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="Contact">ClaimsContact.</param>
        public Contact (IModelManager manager, ClaimsSubject Contact)
            : base (manager, Contact)
        {
        }
        #endregion

        #region Attributes
        public int OrganisationId { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Get the Organisation for this Contact
        /// </summary>
        public IOrganisation Organisation
        {
            get {
                return Manager
                    .RepositoryFor<IOrganisation> (ClaimsSubject)
                    .Read (OrganisationId);
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}