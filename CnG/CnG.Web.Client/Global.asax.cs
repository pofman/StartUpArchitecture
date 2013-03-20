using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CnG.Foundations.Ioc;
using CnG.Foundations.Mvc;
using CnG.Foundations.Wcf;
using CnG.Web.Client.App_Start;
using Microsoft.Practices.Unity;
using UnityConfiguration;

namespace CnG.Web.Client
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            DependencyFactory.Container.Configure(x => x.AddRegistry<MvcUnityRegistry>());
            DependencyFactory.Container.RegisterType(typeof(IServiceInvoker<>), typeof(ServiceInovker<>));

            DependencyResolver.SetResolver(new MvcDependencyResolver(DependencyResolver.Current));
            GlobalConfiguration.Configuration.DependencyResolver = new MvcDependencyResolver(DependencyResolver.Current);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}