using System;
using System.Data;
using MyTrucking.Prototypes.Api.Model.Interfaces;

namespace MyTrucking.Prototypes.Api.Repository
{
	public interface IRemoveStrategy
	{
		void RemoveObject (IModelObject obj, IDbConnection conn, IDbTransaction trans);
	}
}