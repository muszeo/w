//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Topic.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Model
{
    /// <summary>
    /// Metric Topic Model Object
    /// </summary>
    public class Topic : ModelObject, IContract
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Topic" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Topic (IModelManager manager, ClaimsSubject subject)
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
        /// Get Metrics for this Metric Topic
        /// </summary>
        public IList<IJurisdiction> Metrics
        {
            get {
                return Manager
                    .RepositoryFor<IJurisdiction> (ClaimsSubject)
                    .ReadWhere (
                        $"TopicId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}