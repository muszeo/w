//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Metric.cs
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
using System.Data;
#endregion

namespace W.Api.Model
{
    /// <summary>
    /// Metric Model Object
    /// </summary>
    public class Metric : ModelObject, IJurisdiction
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Metric" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Metric (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Related Entities
        public int TopicId { get; set; }
        public int GroupId { get; set; }

        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        public MetricType Type { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Topic of this Metric, e.g. Performance, Scaling, Usability, Concurrency
        /// </summary>
        public IContract Topic
        {
            get {
                return Manager
                    .RepositoryFor<IContract> (ClaimsSubject)
                    .Read (TopicId);
            }
        }

        /// <summary>
        /// Group of this Metric, an organisational factor
        /// </summary>
        public IClient Group
        {
            get {
                return Manager
                    .RepositoryFor<IClient> (ClaimsSubject)
                    .Read (GroupId);
            }
        }

        /// <summary>
        /// Get Observations for this Metric
        /// </summary>
        public IList<ITimeZone> Observations
        {
            get {
                return Manager
                    .RepositoryFor<ITimeZone> (ClaimsSubject)
                    .ReadWhere (
                        $"MetricId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        /// <summary>
        /// Creates a new Observation for this Metric.
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="sourceId"></param>
        /// <param name="contextId"></param>
        /// <param name="subjectId"></param>
        /// <param name="timestamp"></param>
        /// <param name="nI"></param>
        /// <param name="nD"></param>
        /// <param name="dT"></param>
        /// <param name="t25"></param>
        /// <param name="tX"></param>
        /// <returns></returns>
        public ITimeZone NewObservation (IDbTransaction trans, int sourceId, int contextId, int subjectId, DateTime timestamp, int? nI, decimal? nD, DateTime? dT, string t25, string tX)
        {
            // Create Observation
            ITimeZone _rtn =
                new Observation (Manager, ClaimsSubject) {
                    MetricId = Id,
                    SourceId = sourceId,
                    ContextId = contextId,
                    SubjectId = subjectId,
                    Timestamp = timestamp,
                    nI = nI,
                    nD = nD,
                    dT = dT,
                    tC = t25,
                    tX = tX,
                    CreatedOn = DateTime.Now
                };

            // Save Observation
            Manager
                .RepositoryFor<ITimeZone> (ClaimsSubject)
                .Upsert (_rtn, trans);

            return _rtn;
        }
        #endregion
    }
}