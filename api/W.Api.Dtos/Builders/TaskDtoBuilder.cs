//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       TaskDtoBuilder.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using W.Api.Exceptions;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Dtos.Builders
{

    /// <summary>
    /// TopicDtoBuilder
    /// </summary>
    public static class TopicDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// TaskDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static TaskDto From (this TaskDto dto, ITask model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Related Entities
                dto.ServiceId = model.ServiceId;
                dto.ContractId = model.ContractId;
                dto.Parent__TaskId = model.Parent__TaskId;
                dto.OccursAt__LocationId = model.OccursAt__LocationId;

                // Attributes
                dto.Start = model.Start;
                dto.End = model.End;

                // Audit
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Task");
            }

            return dto;
        }
        #endregion
    }
}