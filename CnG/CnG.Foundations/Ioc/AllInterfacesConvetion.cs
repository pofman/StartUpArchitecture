using System;
using System.Linq;
using Microsoft.Practices.Unity;
using UnityConfiguration;

namespace CnG.Foundations.Ioc
{
    public class AllInterfacesConvetion : IAssemblyScannerConvention, ILifetimePolicyExpression
    {
        private Func<Type, Type, string> getName = (t, tt) => string.Format("{0}_{1}", t.Name, tt.Name);
        private Action<ILifetimePolicyExpression> lifetimePolicyAction;

        /// <summary>
        /// Specify how to resolve the name for the registration.
        /// </summary>
        /// <param name="func">The function to create the name for the specified type.</param>
        /// <returns>
        /// An instance of the <see cref="AddAllConvention"/> that can be used to
        /// further configure the convention.
        /// </returns>
        public AllInterfacesConvetion WithName(Func<Type, Type, string> func)
        {
            getName = func;
            return this;
        }

        public void Using<T>() where T : LifetimeManager, new()
        {
            lifetimePolicyAction = x => x.Using<T>();
        }

        void IAssemblyScannerConvention.Process(Type type, IUnityRegistry registry)
        {
            if (type.CanBeCreated())
            {
                type.GetInterfaces().ForEach(x =>
                    {
                     var expression = registry.Register(x, type);

                    if (lifetimePolicyAction != null)
                        lifetimePolicyAction(expression);
                });
            }
        }
    }
}