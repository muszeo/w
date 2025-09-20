//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewTopicDto.cs
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
    public class NewTopicDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
    }
}