//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ResourceDtoBuilder.cs
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
    /// ResourceDtoBuilder
    /// </summary>
    public static class ResourceDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// ResourceDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static ResourceDto From (this ResourceDto dto, IResource model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Attributes
                dto.Name = model.Name;
                dto.Description = model.Description;
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Resource");
            }

            return dto;
        }
        #endregion
    }
}