//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       SiteDto.cs
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
    public class SiteDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDto"/> class.
        /// </summary>
        public SiteDto () : base () { }
        #endregion

        #region Attributes
        // Related Entities
        public int OperatedBy__OrganisationId { get; set; }

        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }

        // Audit
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}