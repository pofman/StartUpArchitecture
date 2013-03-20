using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using CnG.Foundations.Ioc;

namespace CnG.Web.Client
{
    public class ControllerFactory : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return (IController)DependencyFactory.Resolve(controllerType);
        }
    }

    public class UnityHttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)DependencyFactory.Resolve(controllerType);
        }
    }
}