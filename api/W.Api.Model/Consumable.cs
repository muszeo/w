//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Consumable.cs
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
    /// Consumable Model Object
    /// </summary>
    public class Consumable : Resource, IConsumable
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Consumable" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Consumable (IModelManager manager, ClaimsSubject subject)
            : base (manager, subject)
        {
        }
        #endregion

        #region Attributes
        #endregion

        #region Related Entities
        #endregion

        #region Public Operations
        #endregion
    }
}