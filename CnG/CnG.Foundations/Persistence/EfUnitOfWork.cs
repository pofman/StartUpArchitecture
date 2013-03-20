using System;

namespace CnG.Foundations.Persistence
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IContextFactory _contextFactory;

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
            get { return _contextFactory.Current; }
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