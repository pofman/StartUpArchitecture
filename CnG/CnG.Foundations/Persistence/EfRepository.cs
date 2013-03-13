using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CnG.Foundations.Persistence
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IPersistenceContext _persistenceContext;

        public EfRepository(IPersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return GetQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { return GetQueryable().Expression; }
        }

        public Type ElementType
        {
            get { return GetQueryable().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return GetQueryable().Provider; }
        }

        public void Put(TEntity entity)
        {
            _persistenceContext.GetDbSet<TEntity>().Add(entity);
        }

        public TEntity this[object id]
        {
            get { return _persistenceContext.GetDbSet<TEntity>().Find(id); }
        }

        public void Remove(TEntity entity)
        {
            _persistenceContext.GetDbSet<TEntity>().Remove(entity);
        }

        protected IQueryable<TEntity> GetQueryable()
        {
            return _persistenceContext.GetDbSet<TEntity>();
        }
    }
}
