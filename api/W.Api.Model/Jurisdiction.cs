//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Jurisdiction.cs
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
    /// Jurisdiction Model Object
    /// </summary>
    public class Jurisdiction : ModelObject, IJurisdiction
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Jurisdiction" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="Jurisdiction">ClaimsJurisdiction.</param>
        public Jurisdiction (IModelManager manager, ClaimsSubject Jurisdiction)
            : base (manager, Jurisdiction)
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