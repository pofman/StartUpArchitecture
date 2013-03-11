using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace CnG.Foundations.Ioc
{
    public class DependencyFactory
    {
        public static IUnityContainer Container { get; private set; }

        static DependencyFactory()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
            Container = container;
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
    }
}
