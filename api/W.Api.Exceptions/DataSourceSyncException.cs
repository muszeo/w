//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       DataSourceSyncException.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using System;

namespace W.Api.Exceptions
{
    public class DataSourceSyncException : ApplicationException
    {
        public DataSourceSyncException (string message)
            : base (message)
        {
        }

        public DataSourceSyncException (Exception exception)
            : base ("Data Source Sync Exception", exception)
        {
        }
    }
}