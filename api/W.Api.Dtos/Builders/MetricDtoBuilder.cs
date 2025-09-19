//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       MetricDtoBuilder.cs
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
    /// MetricDtoBuilder
    /// </summary>
    public static class MetricDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// MetricDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static MetricDto From (this MetricDto dto, IJurisdiction model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Attributes
                dto.TopicId = model.TopicId;
                dto.GroupId = model.GroupId;
                dto.Name = model.Name;
                dto.Description = model.Description;
                dto.Type = (int)model.Type;
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Metric");
            }

            return dto;
        }
        #endregion
    }
}