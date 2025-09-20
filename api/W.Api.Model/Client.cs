//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Client.cs
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
    /// Client Model Object
    /// </summary>
    public class Client : ModelObject, IClient
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Client" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Client (IModelManager manager, ClaimsSubject subject)
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
        /// Get Contacts for this Client
        /// </summary>
        public IList<IContact> Contacts
        {
            get {
                return Manager
                    .RepositoryFor<IContact> (ClaimsSubject)
                    .ReadWhere (
                        $"ClientId = {Id}"
                    );
            }
        }

        /// <summary>
        /// Get Contracts for this Client
        /// </summary>
        public IList<IContract> Contracts
        {
            get {
                return Manager
                    .RepositoryFor<IContract> (ClaimsSubject)
                    .ReadWhere (
                        $"ClientId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}