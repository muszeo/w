//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       BusinessRuleException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class BusinessAuthorisationException : ApplicationException
    {
        public BusinessAuthorisationException (string message)
            : base (message)
        {
        }
    }
}