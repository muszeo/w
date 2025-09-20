//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Tenancy.cs
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
    /// Tenancy Model Object
    /// </summary>
    public class Tenancy : ModelObject, ITenancy
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Tenancy" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Tenancy (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        // Attributes
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Related Entities
        #endregion

        #region Public Operations
        #endregion
    }
}