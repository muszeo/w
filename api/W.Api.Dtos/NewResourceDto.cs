//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewResourceDto.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
#endregion

namespace W.Api.Dtos
{
    public class NewResourceDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
    }
}