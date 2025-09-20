//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ServiceDtoBuilder.cs
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
    /// ServiceDtoBuilder
    /// </summary>
    public static class ServiceDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// ServiceDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static ServiceDto From (this ServiceDto dto, IService model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Attributes
                dto.CatalogueId = model.CatalogueId;

                // Audit
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Service");
            }

            return dto;
        }
        #endregion
    }
}