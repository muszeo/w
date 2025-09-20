//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       SiteDtoBuilder.cs
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
    /// SiteDtoBuilder
    /// </summary>
    public static class SiteDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// SiteDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static SiteDto From (this SiteDto dto, ISite model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Related Entities
                dto.OperatedBy__OrganisationId = model.OperatedBy__OrganisationId;

                // Attributes
                dto.Name = model.Name;
                dto.Description = model.Description;

                // Audit
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Site");
            }

            return dto;
        }
        #endregion
    }
}