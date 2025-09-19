//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       NoStrategyException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class NoStrategyException : ApplicationException
    {
        public NoStrategyException (object model)
            : base (model.GetType ().ToString ())
        {
        }

        public NoStrategyException (Type type)
            : base (type.ToString ())
        {
        }
    }
}