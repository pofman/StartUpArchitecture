namespace CnG.Foundations.Persistence
{
	public interface IUnitOfWorkFactory
	{
		IUnitOfWork New();
		IUnitOfWork Current { get; }
	}
}