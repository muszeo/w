using System;
using MyTrucking.Core.Api.Model.Interfaces;

namespace MyTrucking.Core.Api.Repository.Database
{
    public interface IDatabaseModelManager : IModelManager
    {
        void Scoped (Action fn);
    }
}