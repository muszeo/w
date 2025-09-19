using System;
using System.Data;
using System.Collections.Generic;
using MyTrucking.Prototypes.Api.Model.Interfaces;

namespace MyTrucking.Prototypes.Api.Repository
{
    public interface IReadStrategy<T> where T : IModelObject
    {
        T Read (int id, IDbConnection conn);
        IList<T> ReadWhere (string clause, IDbConnection conn);
        IList<T> ReadAll (IDbConnection conn);
    }
}