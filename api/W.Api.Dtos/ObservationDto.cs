//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       ObservationDto.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
#endregion

namespace W.Api.Dtos
{
    public class ObservationDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ObservationDto"/> class.
        /// </summary>
        public ObservationDto () : base () { }
        #endregion

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
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}