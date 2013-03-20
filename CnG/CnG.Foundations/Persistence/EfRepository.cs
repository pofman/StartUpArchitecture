using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CnG.Foundations.Persistence
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IContextFactory _contextFactory;

        public EfRepository(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
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
            _contextFactory.Current.GetDbSet<TEntity>().Add(entity);
        }

        public TEntity this[object id]
        {
            get { return _contextFactory.Current.GetDbSet<TEntity>().Find(id); }
        }

        public void Remove(TEntity entity)
        {
            _contextFactory.Current.GetDbSet<TEntity>().Remove(entity);
        }

        protected IQueryable<TEntity> GetQueryable()
        {
            return _contextFactory.Current.GetDbSet<TEntity>();
        }
    }
}
