namespace CnG.Foundations.Persistence
{
    public interface IContextFactory
    {
        IPersistenceContext Current { get; }
    }
}