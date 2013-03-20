using CnG.Foundations.Contexts;
using CnG.Foundations.Persistence;

namespace CnG.Domain.Model.Mappings.Contexts
{
    public class ContextFactory : IContextFactory
    {
        private const string PersistenceContextKey = "CnCPersistenceContextKey";
        private readonly IExecutionContext _context;

        public ContextFactory(IExecutionContext context)
        {
            _context = context;
        }

        public IPersistenceContext Current
        {
            get
            {
                if (_context.ContainsKey(PersistenceContextKey))
                    return _context.GetObject<IPersistenceContext>(PersistenceContextKey);

                var context = new EfContext();
                _context.SetObject(PersistenceContextKey, context);
                return context;
            }
        }
    }
}