//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Task.cs
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
    /// Task Model Object
    /// </summary>
    public class Task : ModelObject, ITask
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Task" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Task (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int ServiceId { get; set; }
        public int ContractId { get; set; }
        public int Parent__TaskId { get; set; }
        public int OccursAt__LocationId { get; set; }

        // Attributes
        public DateTime? End { get; set; }
        public DateTime? Start { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Gets this Tasks's Contract
        /// </summary>
        public IService Service
        {
            get {
                return Manager
                    .RepositoryFor<IService> (ClaimsSubject)
                    .Read (ServiceId);
            }
        }

        /// <summary>
        /// Gets this Tasks's Contract
        /// </summary>
        public IContract Contract
        {
            get {
                return Manager
                    .RepositoryFor<IContract> (ClaimsSubject)
                    .Read (ContractId);
            }
        }

        /// <summary>
        /// Gets this Tasks's occurance Location
        /// </summary>
        public ILocation OccursAt
        {
            get {
                return Manager
                    .RepositoryFor<ILocation> (ClaimsSubject)
                    .Read (OccursAt__LocationId);
            }
        }

        /// <summary>
        /// Gets this Task's Parent Task (if present, otherwise null)
        /// </summary>
        public ITask Parent
        {
            get {
                return Manager
                    .RepositoryFor<ITask> (ClaimsSubject)
                    .Read (Parent__TaskId);
            }
        }

        /// <summary>
        /// Gets this Task's Child Tasks (Subsidiaries, Departments, Depots etc.)
        /// </summary>
        public IList<ITask> Children
        {
            get {
                return Manager
                    .RepositoryFor<ITask> (ClaimsSubject)
                    .ReadWhere (
                        $"Parent__TaskId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}