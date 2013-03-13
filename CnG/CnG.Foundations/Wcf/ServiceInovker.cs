using System;
using System.ServiceModel;

namespace CnG.Foundations.Wcf
{
    public class ServiceInovker<TContract> : IServiceInvoker<TContract>
    {
        public TResult Invoke<TResult>(Func<TContract, TResult> method)
        {
            var channelFactory = new ChannelFactory<TContract>(typeof(TContract).Name);
            return method(channelFactory.CreateChannel());
        }

        public void Invoke(Action<TContract> method)
        {
            var channelFactory = new ChannelFactory<TContract>(typeof(TContract).Name);
            method(channelFactory.CreateChannel());
        }
    }

    public interface IServiceInvoker<T>
    {
        TResult Invoke<TResult>(Func<T, TResult> method);
        void Invoke(Action<T> method);
    }
}
