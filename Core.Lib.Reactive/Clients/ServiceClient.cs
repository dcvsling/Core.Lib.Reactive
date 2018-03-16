using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{

    internal class ServiceClient<T,TNext> : ServiceClientBase<T,TNext>
    {
        private readonly Func<T,TNext> _func;
        private readonly IServiceClient<T> _client;

        protected internal ServiceClient(IServiceClient<T> client,Func<T,TNext> func,IService<object> decorator)
            : base(decorator)
        {
            _func = func;
            _client = client;
        }

        public override Task Run(IService<TNext> service)
            => _client.Run(new Service<T,TNext>(service, _func));
    }
}
