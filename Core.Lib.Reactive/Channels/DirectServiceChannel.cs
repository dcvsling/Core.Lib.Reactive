using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public class DirectServiceChannel<T> : IServiceChannel<T>
    {
        private IService<T> _input;
        private readonly Action<T> _action;

        public DirectServiceChannel(Action<T> action)
        {
            _input = new Service<T>(action);
            _action = action;
        }
        public void Execute(T value)
        {
            _input.Execute(value);
        }
        public Task Run(IService<T> service)
        {
            _input = new Service<T, T>(service, _action.ReturnSelf());
            return Task.CompletedTask;
        }
    }

    public class NotifyServiceChannel<T> : IServiceChannel<T>
    {
        private IService<T> _input;
        private readonly IService<T> _notify;
        private readonly IService<T> _service;

        public NotifyServiceChannel(IService<T> service, IService<T> notify)
        {
            _notify = notify;
            _service = service;
        }
        public void Execute(T value)
        {
            _input.Execute(value);
        }
        public Task Run(IService<T> service)
        {
            _input = new Service<T,T>(service,((Action<T>)(t => { _service.Execute(t); _notify.Execute(t); })).ReturnSelf());
            return Task.CompletedTask;
        }
    }
}
