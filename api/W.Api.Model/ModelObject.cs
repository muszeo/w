//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ModelObject.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------
#region Usings
using System;
using System.Collections.Generic;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Model
{
    /// <summary>
    ///   ModelOject - base class for models
    /// </summary>
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public abstract class ModelObject : IModelObject
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        #region Public Static Variables
        public static readonly int NEW_ID = -1;
        public static readonly int NULL_ID = -1;
        public static readonly long NEW_STAMP = 0;
        #endregion

        #region Private Member Variables
        private readonly IModelManager theMgr = null;
        private readonly ClaimsSubject theSubject;
        #endregion

        #region Public Attributes / Properties
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } 
        #endregion

        #region Protected Members Variables
        /// <summary>
        /// Gets the current ModelManager.
        /// </summary>
        protected IModelManager Manager
        {
            get => theMgr;
        }

        /// <summary>
        /// Gets the Logged-On Subject.
        /// </summary>
        protected ClaimsSubject ClaimsSubject
        {
            get => theSubject;
        }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="ModelObject" /> class.</summary>
        /// <param name="manager">The manager.</param>
        public ModelObject (IModelManager manager, ClaimsSubject subject)
        {
            Id = NEW_ID;
            theMgr = manager;
            theSubject = subject;
        }
        #endregion

        #region Public Operations
        #endregion

        #region Public Override Operations
        /// <summary>
        /// Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals (object obj)
        {
            return (obj as ModelObject).Id.Equals (Id);
        }
        #endregion
    }
}