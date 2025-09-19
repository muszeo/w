//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Status500Exception.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class Status500Exception : ApplicationException
    {
        public Status500Exception (string description)
            : base ($"Http Status Description: {description}")
        {
        }
    }
}