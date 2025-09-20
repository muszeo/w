//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewContextDto.cs
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
    public class NewContextDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        #endregion
    }
}