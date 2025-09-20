//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       TimeZone.cs
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
    /// TimeZone Model Object
    /// </summary>
    public class TimeZone : ModelObject, ITimeZone
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="TimeZone" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="TimeZone">ClaimsTimeZone.</param>
        public TimeZone (IModelManager manager, ClaimsSubject TimeZone)
            : base (manager, TimeZone)
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