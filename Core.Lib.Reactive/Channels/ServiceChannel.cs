using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public class ServiceChannel<TInput, TOutput> : ServiceChannelBase<TInput,TOutput>
    {
        private readonly IServiceClient<TOutput> _client;
        private readonly IService<TInput> _input;

        public ServiceChannel(IService<TInput> input,IServiceClient<TOutput> client,IService<object> decorator)
            :base(decorator)
        {
            _client = client;
            _input = input;
        }

        public override void Execute(TInput value)
            => _input.Execute(value);
        public override Task Run(IService<TOutput> service)
            => _client.Run(Decorator.Decorate(service));
    }
}
