//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Source.cs
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
    /// Metric Source Model Object
    /// </summary>
    public class Source : ModelObject, IOrganisation
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Source" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Source (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        public string Code { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Get Observations for this Metric Source
        /// </summary>
        public IList<ITimeZone> Observations
        {
            get {
                return Manager
                    .RepositoryFor<ITimeZone> (ClaimsSubject)
                    .ReadWhere (
                        $"SourceId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}