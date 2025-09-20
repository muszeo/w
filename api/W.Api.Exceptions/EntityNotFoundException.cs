//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       EntityNotFoundException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException (string type, int id)
            : base ($"Entity of type '{type}' and id '{id}' was not found.")
        {

        }

        public EntityNotFoundException (string type, string subject)
            : base ($"Entity of type '{type}' and subject_identifier '{subject}' was not found.")
        {

        }
    }
}