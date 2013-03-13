using System.Linq;

namespace CnG.Foundations.Persistence
{
    public interface IRepository<T> : IQueryable<T>
    {
        void Put(T entity);
        T this[object id] { get; }
        void Remove(T entity);
    }
}