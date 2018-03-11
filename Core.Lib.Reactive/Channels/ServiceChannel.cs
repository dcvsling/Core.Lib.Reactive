using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public class ServiceChannel<TInput, TOutput> : IServiceChannel<TInput, TOutput>
    {
        private readonly IServiceClient<TOutput> _client;
        private readonly IService<TInput> _input;

        public ServiceChannel(IService<TInput> input,IServiceClient<TOutput> client)
        {
            _client = client;
            _input = input;
        }
        public void Execute(TInput value)
            => _input.Execute(value);
        public Task Run(IService<TOutput> service)
            => _client.Run(service);
    }
}
