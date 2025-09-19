//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       EntityAlreadyExistsException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class EntityAlreadyExistsException : ApplicationException
    {
        public EntityAlreadyExistsException ()
            : base ()
        {

        }

        public EntityAlreadyExistsException (string type, int id)
            : base ($"Entity of type '{type}' and id '{id}' already exists.")
        {

        }
    }
}