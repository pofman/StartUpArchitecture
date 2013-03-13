using CnG.Foundations.Persistence;
using CnG.Services.Contracts;
using UnityConfiguration;

namespace CnG.Web.Services.Configurations
{
    public class WcfUnityRegistry : UnityRegistry
    {
        public WcfUnityRegistry()
        {
            Scan(scan =>
                {
                    scan.AssemblyContaining<IUserService>();
                    scan.AssemblyContaining<WcfExecutionContext>();
                    scan.AssemblyContaining<IUnitOfWork>();
                    scan.ForRegistries();
                    scan.With<FirstInterfaceConvention>();
                    //scan.With<AddAllConvention>()
                    //    .TypesImplementing<IHaveManyImplementations>();
                    //scan.With<SetAllPropertiesConvention>().OfType<ILogger>();
                    //scan.ExcludeType<FooService>();
                });
        }
    }
}