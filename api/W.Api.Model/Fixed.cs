//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Fixed.cs
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
    /// Fixed Model Object
    /// </summary>
    public class Fixed : Resource, IFixed
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Fixed" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Fixed (IModelManager manager, ClaimsSubject subject)
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