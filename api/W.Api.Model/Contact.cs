//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Contact.cs
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
    /// Contact Model Object
    /// </summary>
    public class Contact : ModelObject, IContact
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Contact" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="Contact">ClaimsContact.</param>
        public Contact (IModelManager manager, ClaimsSubject Contact)
            : base (manager, Contact)
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