using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public class ServiceClient<T,TNext> : IServiceClient<TNext>
    {
        private readonly Func<T,TNext> _func;
        private readonly IServiceClient<T> _client;

        protected internal ServiceClient(IServiceClient<T> client,Func<T,TNext> func)
        {
            _func = func;
            _client = client;
        }

        public Task Run(IService<TNext> service)
            => _client.Run(new Service<T,TNext>(service, _func));
    }
}
