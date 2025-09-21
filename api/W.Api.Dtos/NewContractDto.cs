//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewContractDto.cs
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
    public class NewContractDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
    }
}