namespace CnG.Foundations.Contexts
{
    public interface IExecutionContext
    {
        T GetObject<T>(string key) where T : class;

        bool ContainsKey(string key);

        void SetObject(string key, object val);
    }
}
