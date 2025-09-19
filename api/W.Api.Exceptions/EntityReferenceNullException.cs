//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       EntityReferenceNullException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class EntityReferenceNullException : ApplicationException
    {
        public EntityReferenceNullException ()
            : base ()
        {

        }

        public EntityReferenceNullException (string type)
            : base ($"Entity of type '{type}' was null.")
        {

        }

        public EntityReferenceNullException (string type, int id)
            : base ($"Entity of type '{type}' and id '{id}' was null.")
        {

        }
    }
}