//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NewTaskDto.cs
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
    public class NewTaskDto : NewDtoObject, INewDtoObject
    {
        #region Attributes
        // Related Entities
        public int ServiceId { get; set; }
        public int ContractId { get; set; }
        public int Parent__TaskId { get; set; }
        public int OccursAt__LocationId { get; set; }

        // Attributes
        public DateTime? End { get; set; }
        public DateTime? Start { get; set; }
        #endregion
    }
}