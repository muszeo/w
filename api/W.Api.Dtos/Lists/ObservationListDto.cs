//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ObservationListDto.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System.Collections.Generic;
#endregion

namespace W.Api.Dtos.Lists
{
    public class ObservationListDto : ListDtoObject, IListDtoObject
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ObservationListDto" /> class.</summary>
        public ObservationListDto ()
        {
            Items = new List<ObservationDto> ();
        }
        #endregion

        #region Attributes
        public List<ObservationDto> Items { get; set; }
        #endregion
    }
}