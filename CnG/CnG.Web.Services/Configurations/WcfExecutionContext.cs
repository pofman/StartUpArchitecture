using CnG.Foundations.Contexts;

namespace CnG.Web.Services.Configurations
{
    public class WcfExecutionContext : IExecutionContext
    {
        public void SetObject(string key, object val)
        {
            WcfOperationContext.Current.Items[key] = val;
        }

        public T GetObject<T>(string key) where T : class
        {
            if (WcfOperationContext.Current.Items.ContainsKey(key))
                return WcfOperationContext.Current.Items[key] as T;

            return null;
        }

        public void RemoveObject(string key)
        {
            WcfOperationContext.Current.Items.Remove(key);
        }

        public bool ContainsKey(string key)
        {
            return WcfOperationContext.Current.Items.ContainsKey(key);
        }
    }
}