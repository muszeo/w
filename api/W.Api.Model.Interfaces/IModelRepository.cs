//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IModelRepository.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Data;
using System.Collections.Generic;
#endregion

namespace W.Api.Model.Interfaces
{
    public class ModelJoin<T>
        where T : IModelObject
    {
        public Func<string, string, string> On;
    }

    public interface IModelRepository<T>
        where T : IModelObject
    {
        T Read (int id);
        IList<T> ReadAll (int limit = 0);
        T Upsert (T model, IDbTransaction trans);
        void Remove (T model, IDbTransaction trans);
        void RemoveWhere (string clause, IDbTransaction trans);
        IList<T> ReadWhere (string clause, int limit = 0);
        IList<T> ReadJoin (string join, string clause, int limit = 0);
    }
}