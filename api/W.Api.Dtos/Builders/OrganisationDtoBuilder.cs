//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       OrganisationDtoBuilder.cs
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
    /// SourceDtoBuilder
    /// </summary>
    public static class OrganisationDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// OrganisationDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static OrganisationDto From (this OrganisationDto dto, IOrganisation model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Attributes
                dto.Name = model.Name;
                dto.Description = model.Description;
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Organisation");
            }

            return dto;
        }
        #endregion
    }
}