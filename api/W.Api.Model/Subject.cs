//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Subject.cs
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
    /// Metric Subject Model Object
    /// </summary>
    public class Subject : ModelObject, IResource
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Subject" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Subject (IModelManager manager, ClaimsSubject subject)
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
        /// Get Observations for this Metric Subject
        /// </summary>
        public IList<ITimeZone> Observations
        {
            get {
                return Manager
                    .RepositoryFor<ITimeZone> (ClaimsSubject)
                    .ReadWhere (
                        $"SubjectId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}