//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ContractDto.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
#endregion

namespace W.Api.Dtos
{
    public class ContractDto : DtoObject, IDtoObject
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDto"/> class.
        /// </summary>
        public ContractDto () : base () {}
        #endregion

        #region Attributes
        // Attributes
        public string Name { get; set; }
        public string Description { get; set; }

        // Audit
        public DateTime CreatedOn { get; set; }
        #endregion
    }
}