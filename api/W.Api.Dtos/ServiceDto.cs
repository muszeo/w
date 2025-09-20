//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ServiceDto.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
#endregion

namespace W.Api.Dtos
{
    public class ServiceDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDto"/> class.
        /// </summary>
        public ServiceDto () : base () { }
        #endregion

        #region Attributes
        // Related Entities
        public int CatalogueId { get; set; }

        // Attributes

        // Audit
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}