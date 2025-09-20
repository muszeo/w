//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       BusinessRuleException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class BusinessRuleException : ApplicationException
    {
        public BusinessRuleException (string message)
            : base (message)
        {
        }
    }
}