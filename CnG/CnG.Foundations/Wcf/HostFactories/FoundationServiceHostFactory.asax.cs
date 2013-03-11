using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CnG.Foundations.Ioc;
using Microsoft.Practices.Unity;

namespace CnG.Foundations.Wcf.HostFactories
{
	public abstract class FoundationServiceHostFactory : ServiceHostFactory
	{
		/// <summary>
		/// Creates a <see cref="FoundationServiceHost"/> for a specified type of service with a specific base address. 
		/// </summary>
		/// <returns>
		/// A <see cref="FoundationServiceHost"/> for the type of service specified with a specific base address.
		/// </returns>
		/// <param name="serviceType">
		/// Specifies the type of service to host. 
		/// </param>
		/// <param name="baseAddresses">
		/// The <see cref="T:System.Array"/> of type <see cref="T:System.Uri"/> that contains the base addresses for the service hosted.
		/// </param>
		protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			//Register the service as a type so it can be found from the instance provider
			DependencyFactory.Container.RegisterType(serviceType);

			RegisterDependencies();
			return new FoundationServiceHost(serviceType, baseAddresses);
		}

		/// <summary>
		/// Initialization logic that any derived type would use to set up the ServiceLocator provider.  Look to UnityServiceHostFactory to see how this is done, if implementing for 
		/// another IoC engine.
		/// </summary>
		protected abstract void RegisterDependencies();
	}
}