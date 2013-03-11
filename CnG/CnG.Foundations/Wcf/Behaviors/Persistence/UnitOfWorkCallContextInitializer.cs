using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using CnG.Foundations.Persistence;

namespace CnG.Foundations.Wcf.Behaviors.Persistence
{
	public class UnitOfWorkCallContextInitializer : IUnitOfWorkCallContextInitializer
	{
		public const string UowKey = "WcfServiceUow";

		private IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

		public UnitOfWorkCallContextInitializer(IUnitOfWorkFactory unitOfWorkFactory)
		{
			UnitOfWorkFactory = unitOfWorkFactory;
		}

		public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message)
		{
			return UnitOfWorkFactory.New();
		}

		public void AfterInvoke(object correlationState)
		{
			((IUnitOfWork)correlationState).Commit();
		}
	}

	public interface IUnitOfWorkCallContextInitializer : ICallContextInitializer
	{
	}
}