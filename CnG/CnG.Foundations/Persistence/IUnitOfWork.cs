using System;

namespace CnG.Foundations.Persistence
{
	public interface IUnitOfWork : IDisposable
	{
		IPersistenceContext DbContext { get; }
		void Commit();
		void RollBack();
	}
}