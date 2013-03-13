using System.Collections.Generic;
using System.ServiceModel;

namespace CnG.Web.Services.Configurations
{
    public class WcfOperationContext : IExtension<OperationContext>
    {
        private static WcfOperationContext _instanceContext;

        private WcfOperationContext()
        {
            Items = new Dictionary<string, object>();
        }

        public IDictionary<string, object> Items { get; set; }

        public static WcfOperationContext Current
        {
            get
            {
                if (OperationContext.Current != null)
                {
                    var context = OperationContext.Current.Extensions.Find<WcfOperationContext>();
                    if (context == null)
                    {
                        context = new WcfOperationContext();
                        OperationContext.Current.Extensions.Add(context);
                    }
                    return context;
                }

                return _instanceContext ?? (_instanceContext = new WcfOperationContext());
            }
        }

        public void Attach(OperationContext owner) { }
        public void Detach(OperationContext owner) { }
    }
}