//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       NewHomogeneousObservationDto.cs
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
    public class NewHomogeneousObservationDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        // We do not include MetricId here because an Observation is a **composite** of a Metric.
        // The MetricId for a new Observation is passed to the MetricController via the route {id}.
        // The MetricController is responsible for managing Observations (as well as Metrics themselves).
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