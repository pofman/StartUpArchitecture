using CnG.Foundations.Ioc;
using CnG.Services.Contracts;
using CnG.Web.Client.Controllers;
using UnityConfiguration;

namespace CnG.Web.Client
{
    public class MvcUnityRegistry : UnityRegistry
    {
        public MvcUnityRegistry()
        {
            Scan(scan =>
                {
                    scan.AssemblyContaining<IUserService>();
                    scan.AssemblyContaining<HomeController>();
                    scan.ForRegistries();
                    scan.With<AllInterfacesConvetion>();
                });
        }
    }
}