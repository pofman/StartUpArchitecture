using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace CnG.Foundations.Wcf.Behaviors.Ioc
{
    public class DependencyInjectionServiceBehavior : IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription,
                                         System.ServiceModel.ServiceHostBase serviceHostBase,
                                         System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
                                         System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (var cdb in serviceHostBase.ChannelDispatchers)
            {
                var cd = cdb as ChannelDispatcher;

                if (cd != null)
                {
                    foreach (var ed in cd.Endpoints)
                    {
                        ed.DispatchRuntime.InstanceProvider = new DependencyInjectionInstanceProvider(serviceDescription.ServiceType);
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        { }
    }
}