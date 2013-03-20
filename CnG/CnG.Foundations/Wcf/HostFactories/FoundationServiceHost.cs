using System;
using System.ServiceModel;
using CnG.Foundations.Wcf.Behaviors.Ioc;
using CnG.Foundations.Wcf.Behaviors.Persistence;

namespace CnG.Foundations.Wcf.HostFactories
{
    public class FoundationServiceHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoundationServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public FoundationServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        { }

        /// <summary>
        /// Opens the channel dispatchers.
        /// </summary>
        /// <param name="timeout">The <see cref="T:System.Timespan"/> that specifies how long the on-open operation has to complete before timing out.</param>
        protected override void OnOpen(TimeSpan timeout)
        {
            Description.Behaviors.Add(new DependencyInjectionServiceBehavior());
			Description.Behaviors.Add(new UnitOfWorkEndpointBehaviorAttribute());
            Description.Behaviors.Find<ServiceBehaviorAttribute>().InstanceContextMode = InstanceContextMode.Single;
            base.OnOpen(timeout);
        }
    }
}