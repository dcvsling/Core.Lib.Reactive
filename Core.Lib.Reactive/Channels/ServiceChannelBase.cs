using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{

    public abstract class ServiceChannelBase<TInput, TOutput> : IServiceChannel<TInput, TOutput>,IServiceClientProvider<TOutput>
    {
        protected ServiceChannelBase(IService<object> decorator)
        {
            Decorator = decorator;
        }

        public IService<object> Decorator { get; }
        public IServiceClient<TNext> Create<TNext>(Func<TOutput,TNext> func)
            => new ServiceClient<TOutput, TNext>(this, func, Decorator);
        public abstract void Execute(TInput value);
        public abstract Task Run(IService<TOutput> service);
    }
}
