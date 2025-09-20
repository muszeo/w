//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       MetricDto.cs
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
    public class MetricDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricDto"/> class.
        /// </summary>
        public MetricDto () : base () {}
        #endregion

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