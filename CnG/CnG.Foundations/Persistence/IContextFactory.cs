namespace CnG.Foundations.Persistence
{
    public interface IContextFactory
    {
        IPersistenceContext Create();
    }
}