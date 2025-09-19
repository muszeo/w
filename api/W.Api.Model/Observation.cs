//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Observation.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Text.Json.Nodes;
using System.Collections.Generic;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Model
{
    /// <summary>
    /// Metric Observation Model Object
    /// </summary>
    public class Observation : ModelObject, ITimeZone
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Observation" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Observation (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        public int MetricId { get; set; }
        public int SourceId { get; set; }
        public int ContextId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Timestamp { get; set; }

        // Value Attributes
        public int? nI { get; set; }
        public decimal? nD { get; set; }
        public DateTime? dT { get; set; }
        public string tC { get; set; }
        public string tX { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Metric for this Observation
        /// </summary>
        public IJurisdiction Metric
        {
            get {
                return Manager
                    .RepositoryFor<IJurisdiction> (ClaimsSubject)
                    .Read (MetricId);
            }
        }

        /// <summary>
        /// Source of this Observation
        /// </summary>
        public IOrganisation Source
        {
            get {
                return Manager
                    .RepositoryFor<IOrganisation> (ClaimsSubject)
                    .Read (SourceId);
            }
        }

        /// <summary>
        /// Context of this Observation
        /// </summary>
        public IContext Context
        {
            get {
                return Manager
                    .RepositoryFor<IContext> (ClaimsSubject)
                    .Read (ContextId);
            }
        }

        /// <summary>
        /// Subject of this Observation
        /// </summary>
        public IResource Subject
        {
            get {
                return Manager
                    .RepositoryFor<IResource> (ClaimsSubject)
                    .Read (SubjectId);
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}