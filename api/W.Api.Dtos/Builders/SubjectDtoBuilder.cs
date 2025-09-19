//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       SubjectDtoBuilder.cs
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
    /// SubjectDtoBuilder
    /// </summary>
    public static class SubjectDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// SubjectDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static SubjectDto From (this SubjectDto dto, IResource model)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Attributes
                dto.Name = model.Name;
                dto.Description = model.Description;
                dto.CreatedOn = model.CreatedOn;

            } else {
                throw new EntityReferenceNullException ("Subject");
            }

            return dto;
        }
        #endregion
    }
}