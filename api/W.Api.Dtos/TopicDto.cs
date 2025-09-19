//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       TopicDto.cs
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
    public class TopicDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicDto"/> class.
        /// </summary>
        public TopicDto () : base () { }
        #endregion

        #region Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}