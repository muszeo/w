//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewMetricDto.cs
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
    public class NewMetricDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        public int TopicId { get; set; }
        public int GroupId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}