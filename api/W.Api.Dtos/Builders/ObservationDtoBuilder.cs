//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       ObservationDtoBuilder.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using W.Api.Settings;
using W.Api.Exceptions;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Dtos.Builders
{

    /// <summary>
    /// ObservationDtoBuilder
    /// </summary>
    public static class ObservationDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// MetricDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static ObservationDto From (this ObservationDto dto, ITimeZone model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Attributes
                dto.MetricId = model.MetricId;
                dto.SourceId = model.SourceId;
                dto.ContextId = model.ContextId;
                dto.SubjectId = model.SubjectId;
                dto.Timestamp = model.Timestamp;
                dto.nI = model.nI;
                dto.nD = model.nD;
                dto.dT = model.dT;
                dto.tC = model.tC;
                dto.tX = model.tX;
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Observation");
            }

            return dto;
        }
        #endregion
    }
}