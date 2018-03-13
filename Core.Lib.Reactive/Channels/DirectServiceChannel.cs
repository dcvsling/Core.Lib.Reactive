using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public class DirectServiceChannel<T> : ServiceChannelBase<T, T>,IServiceChannel<T>
    {
        private IService<T> _input;
        private readonly Action<T> _action;

        public DirectServiceChannel(Action<T> action)
            : base(new Service<object>())
        {
            _input = Decorator.Decorate(new Service<T>(action));
            _action = action;
        }
        public override void Execute(T value)
            => _input.Execute(value);
        public override Task Run(IService<T> service)
        {
            _input = _input.Merge(service);
            return Task.CompletedTask;
        }
    }
}
