//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       DtoObject.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

namespace W.Api.Dtos
{
    public abstract class DtoObject : IDtoObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DtoObject"/> class.
        /// </summary>
        public DtoObject ()
        {
        }
        #endregion

        #region Attributes
        public int Id { get; set; }
        #endregion
    }
}