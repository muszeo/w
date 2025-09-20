//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       StatusCodeException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;
using System.Net;

namespace W.Api.Exceptions
{
    public class StatusCodeException : ApplicationException
    {
        public StatusCodeException (HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public StatusCodeException (HttpStatusCode statusCode, string description)
        {
            StatusCode = statusCode;
            Description = description;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Description { get; set; }
    }
}