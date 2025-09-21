//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewCatalogueDto.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Collections.Generic;
#endregion

namespace W.Api.Dtos
{
    public class NewCatalogueDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
    }
}