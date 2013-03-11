using System;
using System.Data.Entity;

namespace CnG.Foundations.Persistence
{
	public interface IPersistenceContext : IDisposable
	{
		DbSet<T> GetDbSet<T>() where T : class;
		DbContext InnerContext { get; }
	}
}
