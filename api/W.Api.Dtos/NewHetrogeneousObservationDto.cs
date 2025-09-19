//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       NewHetrogeneousObservationDto.cs
//  Desciption: 
//
//  (c) , 2025
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
    public class NewHetrogeneousObservationDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        public int MetricId { get; set; }
        public int SourceId { get; set; }
        public int ContextId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Timestamp { get; set; }
        public int? nI { get; set; }
        public decimal? nD { get; set; }
        public DateTime? dT { get; set; }
        public string tC { get; set; }
        public string tX { get; set; }
        #endregion
    }
}