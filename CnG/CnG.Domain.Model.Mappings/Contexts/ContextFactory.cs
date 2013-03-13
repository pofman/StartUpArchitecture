using CnG.Foundations.Persistence;

namespace CnG.Domain.Model.Mappings.Contexts
{
    public class ContextFactory : IContextFactory
    {
        public IPersistenceContext Create()
        {
            return new EfContext();
        }
    }
}