//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IdentityContext.cs
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
    /// IdentityContext Model Object
    /// </summary>
    public class IdentityContext : Context, ILocation
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="IdentityContext" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public IdentityContext (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        public string SubjectIdentifier { get; set; }
        public string Provider { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        #endregion

        #region Related Entities
        #endregion

        #region Public Operations
        #endregion
    }
}