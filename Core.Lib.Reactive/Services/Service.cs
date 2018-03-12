using System;

namespace Core.Lib.Reactive
{

    public class Service<T> : IService<T>
    {
        private readonly Action<T> _action;
        private readonly IService<T> _service;

        internal Service() : this(_ => { }) { }
        
        public Service(Action<T> action)
        {
            _action = action;
        }

        public void Execute(T value)
        {
            _action(value);
        }
    }
}
