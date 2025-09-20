//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       NoApiEndpointException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class NoApiEndpointException : ApplicationException
    {
        public NoApiEndpointException (string verb, string type)
            : base ($"No Endpoint for '{verb}' for DTO type '{type}'")
        {
        }
    }
}