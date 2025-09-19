//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Context.cs
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
    /// Context Model Object
    /// </summary>
    public abstract class Context : ModelObject, IContext
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Context" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Context (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        #endregion

        #region Related Entities
        /// <summary>
        /// Get Observations for this IdentityContext
        /// </summary>
        public IList<ITimeZone> Observations
        {
            get {
                return Manager
                    .RepositoryFor<ITimeZone> (ClaimsSubject)
                    .ReadWhere (
                        $"ContextId = {Id}"
                    );
            }
        }
        #endregion

        #region Public Operations
        #endregion
    }
}