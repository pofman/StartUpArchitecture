using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using CnG.Foundations.Ioc;

namespace CnG.Foundations.Wcf.Behaviors.Persistence
{
	[AttributeUsage(AttributeTargets.Class)]
	public class UnitOfWorkEndpointBehaviorAttribute : Attribute, IServiceBehavior
	{
		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
		}

		public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			foreach (var operation in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>()
			                                         .SelectMany(cd => cd.Endpoints.SelectMany(ed => ed.DispatchRuntime.Operations)))
			{
				//if (!operation.Action.Equals("*")) //to avoid root call
				operation.CallContextInitializers.Add(DependencyFactory.Resolve<IUnitOfWorkCallContextInitializer>());
			}
		}
	}
}