using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using CnG.Foundations.Ioc;

namespace CnG.Foundations.Wcf.Behaviors.Ioc
{
    public class DependencyInjectionInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;

        public DependencyInjectionInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return DependencyFactory.Resolve(_serviceType);
        }
        
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}