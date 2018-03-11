using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public class DirectServiceChannel<T> : IServiceChannel<T, T>
    {
        private IService<T> _input;
        private IService<T> _merge = default;
        private IServiceClient<T> _client = default;
        public DirectServiceChannel(IService<T> service = default)
        {
            _input = service;
            _client = new ServiceClient<T, T>(this, _ => default);
        }
        public void Execute(T value)
        {
            (_merge ?? _input)?.Execute(value);
        }
        public Task Run(IService<T> service)
        {
            _merge = MergeService(service);
            return Task.CompletedTask;
        }

        private IService<T> MergeService(IService<T> other)
            => new Service<T>(t =>
            {
                _input?.Execute(t);
                other.Execute(t);
            });
    }
}
