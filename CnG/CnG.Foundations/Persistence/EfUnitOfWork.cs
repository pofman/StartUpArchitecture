using System;

namespace CnG.Foundations.Persistence
{
	public class EfUnitOfWork : IUnitOfWork
	{
		private readonly IContextFactory _contextFactory;
		private IPersistenceContext _persistenceContext;

		public EfUnitOfWork(IContextFactory contextFactory)
		{
			_contextFactory = contextFactory;
		}

		void IDisposable.Dispose()
		{
			DbContext.Dispose();
		}

		public IPersistenceContext DbContext
		{
			get
			{
				if (_persistenceContext == null)
					_persistenceContext = _contextFactory.Create();
				return _persistenceContext;
			}
		}

		public void Commit()
		{
			DbContext.InnerContext.ChangeTracker.DetectChanges();
			DbContext.InnerContext.SaveChanges();
		}

		public void RollBack()
		{

		}
	}
}