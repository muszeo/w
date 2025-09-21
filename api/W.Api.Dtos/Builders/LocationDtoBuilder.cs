//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       LocationDtoBuilder.cs
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
    /// LocationDtoBuilder
    /// </summary>
    public static class LocationDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// LocationDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static LocationDto From (this LocationDto dto, ILocation model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Related Entities
                dto.TimeZoneId = model.TimeZoneId;
                dto.GovernedBy__JurisdictionId = model.GovernedBy__JurisdictionId;

                // Attributes

                // Audit
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Location");
            }

            return dto;
        }
        #endregion
    }
}