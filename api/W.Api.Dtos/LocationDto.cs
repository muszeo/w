//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       LocationDto.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
#endregion

namespace W.Api.Dtos
{
    public class LocationDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationDto"/> class.
        /// </summary>
        public LocationDto () : base () { }
        #endregion

        #region Attributes
        // Related Entities
        public int TimeZoneId { get; set; }
        public int GovernedBy__JurisdictionId { get; set; }

        // Attributes

        // Audit
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}