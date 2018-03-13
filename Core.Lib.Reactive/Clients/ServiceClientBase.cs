using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    internal abstract class ServiceClientBase<T,TNext> : IServiceClient<TNext>, IServiceClientProvider<TNext>
    {
        protected ServiceClientBase(IServiceClient<TNext> client)
        {
            Decorator = client is ServiceClientBase<T, TNext> c ? c.Decorator : new Service<object>();
        }
        protected ServiceClientBase(IService<object> decorator)
        {
            Decorator = decorator;
        }
        protected IService<object> Decorator { get; }

        Task IServiceClient<TNext>.Run(IService<TNext> service)
            => Run(Decorator.Decorate(service));

        public abstract Task Run(IService<TNext> service);
        public IServiceClient<TNew> Create<TNew>(Func<TNext, TNew> func)
            => new ServiceClient<TNext,TNew>(this, func, Decorator);
    }
}
