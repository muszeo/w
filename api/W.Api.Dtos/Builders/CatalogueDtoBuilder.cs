//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       CatalogueDtoBuilder.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using W.Api.Exceptions;
using W.Api.Model.Interfaces;
using System.Collections.Generic;
#endregion

namespace W.Api.Dtos.Builders
{

    /// <summary>
    /// CatalogueDtoBuilder
    /// </summary>
    public static class CatalogueDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// CatalogueDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static CatalogueDto From (this CatalogueDto dto, ICatalogue model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Attributes
                dto.Name = model.Name;
                dto.Description = model.Description;
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Catalogue");
            }

            return dto;
        }
        #endregion
    }
}