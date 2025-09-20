//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Allocation.cs
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
    /// Allocation Model Object
    /// </summary>
    public abstract class Allocation : ModelObject, IAllocation
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Allocation" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Allocation (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        public int TaskId { get; set; }
        public int ResourceId { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Get this Allocation's allocated Task
        /// </summary>
        public ITask Task
        {
            get {
                return Manager
                    .RepositoryFor<ITask> (ClaimsSubject)
                    .Read (TaskId);
            }
        }

        /// <summary>
        /// Get this Allocation's allocated Resource
        /// </summary>
        public IResource Resource
        {
            get {
                return Manager
                    .RepositoryFor<IResource> (ClaimsSubject)
                    .Read (ResourceId);
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}