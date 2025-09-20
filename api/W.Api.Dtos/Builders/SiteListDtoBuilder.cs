//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       SiteListDtoBuilder.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using W.Api.Dtos.Lists;
using W.Api.Model.Interfaces;
using System.Collections.Generic;
#endregion

namespace W.Api.Dtos.Builders
{
    public static class SiteListDtoBuilder
    {
        /// <summary>Maps Model to List of Site Dto.</summary>
        /// <param name="dto">The Site dto.</param>
        /// <param name="model">The Site model.</param>
        /// <returns>
        ///   SiteListDto
        /// </returns>
        public static SiteListDto From (this SiteListDto dto, IList<ISite> model)
        {
            foreach (ISite _m in model) {
                dto.Items.Add (
                    new SiteDto ().From (_m)
                );
            }
            return dto;
        }
    }
}