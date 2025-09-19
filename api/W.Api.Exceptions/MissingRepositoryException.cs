//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       MissingRepositoryException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class MissingRepositoryException : ApplicationException
    {
        public MissingRepositoryException (string message)
            : base (message)
        {
        }
    }
}