using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using CnG.Foundations.Ioc;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace CnG.Foundations.Mvc
{
    public class MvcDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver, IServiceLocator
    {
        private readonly IDependencyResolver _dependencyResolver;

        public MvcDependencyResolver(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        public object GetService(Type serviceType)
        {
            return GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return GetAllInstances(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }

        public object GetInstance(Type serviceType)
        {
            return GetInstance(serviceType, string.Empty);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return GetSingleInstanceFromResolver(serviceType);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return GetMultipleInstanceFromResolver(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return GetInstance<TService>(string.Empty);
        }

        public TService GetInstance<TService>(string key)
        {
            return GetSingleInstanceFromResolver<TService>();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return GetMultipleInstanceFromResolver<TService>();
        }

        private T GetSingleInstanceFromResolver<T>()
        {
            try
            {
                var instance = DependencyFactory.Resolve<T>();
                if (instance == null)
                    instance = (T)_dependencyResolver.GetService(typeof(T));
                return instance;
            }
            catch (Exception)
            {
                return (T)_dependencyResolver.GetService(typeof(T));
            }
        }

        private object GetSingleInstanceFromResolver(Type dependencyType)
        {
            try
            {
                var instance = DependencyFactory.Resolve(dependencyType);
                if (instance == null)
                    instance = _dependencyResolver.GetService(dependencyType);
                return instance;
            }
            catch (Exception)
            {
                return _dependencyResolver.GetService(dependencyType);
            }
        }

        private IEnumerable<T> GetMultipleInstanceFromResolver<T>()
        {
            try
            {
                var instance = DependencyFactory.Container.ResolveAll<T>();
                if (instance == null)
                    instance = _dependencyResolver.GetServices(typeof(T)).Cast<T>();
                return instance;
            }
            catch (Exception)
            {
                return _dependencyResolver.GetServices(typeof(T)).Cast<T>();
            }
        }

        private IEnumerable<object> GetMultipleInstanceFromResolver(Type dependencyType)
        {
            try
            {
                var instance = DependencyFactory.Container.ResolveAll(dependencyType);
                if (instance == null)
                    instance = _dependencyResolver.GetServices(dependencyType);
                return instance;
            }
            catch (Exception)
            {
                return _dependencyResolver.GetServices(dependencyType);
            }
        }
    }
}