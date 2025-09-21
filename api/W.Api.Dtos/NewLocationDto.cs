//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewLocationDto.cs
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
    public class NewLocationDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="NewLocationDto"/> class.
        /// </summary>
        public NewLocationDto () : base () { }
        #endregion

        #region Attributes
        // Related Entities
        public int TimeZoneId { get; set; }
        public int GovernedBy__JurisdictionId { get; set; }

        // Attributes
        #endregion
    }
}