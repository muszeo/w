//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ContextDto.cs
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
    public class AutoObserveDto : DtoObject, IDtoObject
    {
        public string MetricId { get; set; }
        public string Role { get; set; }
        public string Args { get; set; }
        public string Recur { get; set; }
    }

    public class ContextDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextDto"/> class.
        /// </summary>
        public ContextDto () : base () { }
        #endregion

        #region Attributes
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string SubjectIdentifier { get; set; }
        public string Provider { get; set; }
        public string QueueFor { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<AutoObserveDto> AutoObserve { get; set; }
        #endregion
    }
}