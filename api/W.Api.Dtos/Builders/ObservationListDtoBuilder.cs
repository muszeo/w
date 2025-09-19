//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       ObservationListDtoBuilder.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using W.Api.Dtos.Lists;
using W.Api.Model.Interfaces;
using System.Collections.Generic;
#endregion

namespace W.Api.Dtos.Builders
{
    public static class ObservationListDtoBuilder
    {
        /// <summary>Maps User Model to List of Observation Dto.</summary>
        /// <param name="dto">The Observation dto.</param>
        /// <param name="model">The Observation model.</param>
        /// <returns>
        ///   ObservationListDto
        /// </returns>
        public static ObservationListDto From (this ObservationListDto dto, IList<ITimeZone> model)
        {
            foreach (ITimeZone _o in model) {
                dto.Items.Add (
                    new ObservationDto ().From (_o)
                );
            }
            return dto;
        }
    }
}