//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       OrganisationDto.cs
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
    public class OrganisationDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganisationDto"/> class.
        /// </summary>
        public OrganisationDto () : base () { }
        #endregion

        #region Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}