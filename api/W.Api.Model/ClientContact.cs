//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ClientContact.cs
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
    /// ClientContact Model Object
    /// </summary>
    public class ClientContact : ModelObject, IClientContact
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ClientContact" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public ClientContact (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int ClientId { get; set; }
        public int ContactId { get; set; }

        // Attributes
        #endregion

        #region Related Entities
        /// <summary>
        /// Gets this ClientContact's Client
        /// </summary>
        public IClient Client
        {
            get {
                return Manager
                    .RepositoryFor<IClient> (ClaimsSubject)
                    .Read (ClientId);
            }
        }

        /// <summary>
        /// Gets this ClientContact's Contact
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