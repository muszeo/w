//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IModelManager.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Data;
using W.Api.Authorisation;
#endregion

namespace W.Api.Model.Interfaces
{
    public interface IModelManager
    {
        void Open ();
        void Close ();
        void Scoped (Action<IDbTransaction> fn);
        IModelRepository<T> RepositoryFor<T> (ClaimsSubject subject) where T : IModelObject;
    }
}