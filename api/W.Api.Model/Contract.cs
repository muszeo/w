//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Contract.cs
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
    /// Contract Model Object
    /// </summary>
    public class Contract : ModelObject, IContract
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Contract" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Contract (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int With__ClientId { get; set; }

        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Get the Client for this Contract
        /// </summary>
        public IClient With
        {
            get {
                return Manager
                    .RepositoryFor<IClient> (ClaimsSubject)
                    .Read (With__ClientId);
            }
        }

        /// <summary>
        /// Get Tasks for this Contract
        /// </summary>
        public IList<ITask> Tasks
        {
            get {
                return Manager
                    .RepositoryFor<ITask> (ClaimsSubject)
                    .ReadWhere (
                        $"ContractId = {Id}"
                    );
            }
        }

        /// <summary>
        /// Get Services for this Contract
        /// </summary>
        public IList<IService> Services
        {
            get {
                return Manager
                    .RepositoryFor<IService> (ClaimsSubject)
                    .ReadWhere (
                        $"ContractId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}