//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       OptimisticLockingException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class OptimisticLockingException : ApplicationException
    {
        public OptimisticLockingException (string message)
            : base ($"Optimistic Locking Exception: {message}")
        {
        }

        public OptimisticLockingException (Exception exception)
            : base ("Optimistic Locking Exception", exception)
        {
        }
    }
}