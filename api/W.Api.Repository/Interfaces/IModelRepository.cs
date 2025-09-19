using MyTrucking.Core.Api.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;  

namespace MyTrucking.Core.Api.Repository.Interfaces
{
    public interface IModelRepository<T>
          where T : IModelObject
    {
        T Read(int id);
        IList<T> ReadAll();
        IList<T> ReadWhere(string clause);
        T Upsert(T model, IDbTransaction trans);
        void Remove(T model, IDbTransaction trans);
    }
}
