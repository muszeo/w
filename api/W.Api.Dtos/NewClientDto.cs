//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewClientDto.cs
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
    public class NewClientDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
    }
}