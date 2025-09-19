//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       DataSourceConnectionException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class DataSourceConnectionException : ApplicationException
    {
        public DataSourceConnectionException (string message, Exception exception)
            : base (message, exception)
        {
        }
    }
}