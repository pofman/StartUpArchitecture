using CnG.Foundations.Contexts;

namespace CnG.Web.Services.Configurations
{
    public class WcfExecutionContext : IExecutionContext
    {
        public T GetObject<T>(string key) where T : class
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new System.NotImplementedException();
        }

        public void SetObject(string key, object val)
        {
            throw new System.NotImplementedException();
        }
    }
}