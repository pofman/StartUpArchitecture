using CnG.Foundations.Ioc;
using CnG.Foundations.Persistence;
using CnG.Foundations.Wcf.HostFactories;
using Microsoft.Practices.Unity;
using UnityConfiguration;

namespace CnG.Web.Services.Configurations
{
    public class CnGServiceHostFactory : FoundationServiceHostFactory
    {
        protected override void RegisterDependencies()
        {
            DependencyFactory.Container.Configure(x => x.AddRegistry<WcfUnityRegistry>());
            DependencyFactory.Container.RegisterType(typeof (IRepository<>), typeof (EfRepository<>));
        }
    }
}