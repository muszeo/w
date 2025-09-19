using System;

namespace MyTrucking.Prototypes.Api.Repository
{
	public interface IRepository
	{
		string ConnectionString { get; }
		string Name { get; }
	}
}