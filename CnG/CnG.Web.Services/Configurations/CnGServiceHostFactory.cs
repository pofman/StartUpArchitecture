using CnG.Foundations.Ioc;
using CnG.Foundations.Wcf.HostFactories;
using UnityConfiguration;

namespace CnG.Web.Services.Configurations
{
    public class CnGServiceHostFactory : FoundationServiceHostFactory
    {
        protected override void RegisterDependencies()
        {
            DependencyFactory.Container.Configure(x => x.AddRegistry<WcfUnityRegistry>());
        }
    }
}