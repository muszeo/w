//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       SiteListDto.cs
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
    public class SiteListDto : ListDtoObject, IListDtoObject
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="SiteListDto" /> class.</summary>
        public SiteListDto ()
        {
            Items = new List<SiteDto> ();
        }
        #endregion

        #region Attributes
        public List<SiteDto> Items { get; set; }
        #endregion
    }
}