using System;
using System.Data;
using MyTrucking.Prototypes.Api.Model.Interfaces;

namespace MyTrucking.Prototypes.Api.Repository
{
	public interface ISyncStrategy
	{
		void SyncObject (IModelObject obj, IDbConnection conn, IDbTransaction trans);
	}
}