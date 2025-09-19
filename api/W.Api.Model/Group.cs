//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Group.cs
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
    /// Metric Group Model Object
    /// </summary>
    public class Group : ModelObject, IClient
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Group" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Group (IModelManager manager, ClaimsSubject subject)
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
        /// Get Metrics for this Metric Group
        /// </summary>
        public IList<IJurisdiction> Metrics
        {
            get {
                return Manager
                    .RepositoryFor<IJurisdiction> (ClaimsSubject)
                    .ReadWhere (
                        $"GroupId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}