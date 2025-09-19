//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       NewSubjectDto.cs
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
    public class NewSubjectDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
    }
}