using CnG.Foundations.Contexts;

namespace CnG.Foundations.Persistence
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		public const string UowKey = "GPS.Rearchitecture.UowKey";
		private readonly IExecutionContext _context;
		private readonly IContextFactory _contextFactory;

		public UnitOfWorkFactory(IExecutionContext context, IContextFactory contextFactory)
		{
			_context = context;
			_contextFactory = contextFactory;
		}

		public IUnitOfWork New()
		{
			var uow = new EfUnitOfWork(_contextFactory);
			_context.SetObject(UowKey, uow);
			return uow;
		}

		public IUnitOfWork Current
		{
			get
			{
				if (_context.ContainsKey(UowKey))
				{
					return _context.GetObject<IUnitOfWork>(UowKey);
				}
				return null;
			}
		}
	}
}