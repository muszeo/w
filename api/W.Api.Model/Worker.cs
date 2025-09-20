//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       Worker.cs
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
    /// Worker Model Object
    /// </summary>
    public class Worker : Resource, IWorker
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="Worker" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public Worker (IModelManager manager, ClaimsSubject subject)
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