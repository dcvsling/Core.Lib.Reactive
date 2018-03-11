using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public class ServiceClient<T> : IServiceClient<T>
    {
        private readonly IServiceClient<T> _client;

        protected internal ServiceClient(IServiceClient<T> client)
        {
            _client = client;
        }

        public Task Run(IService<T> service)
            => _client.Run(new Service<T>(service.Execute));
    }
}
