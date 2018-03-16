using System;

namespace Core.Lib.Reactive
{

    public class Service<T> : ServiceBase<T>, IService<T>
    {
        private readonly Action<T> _action;

        internal Service() : this(_ => { }) { }
        
        public Service(Action<T> action)
        {
            _action = action;
        }

        public override void Execute(T value)
            => _action(value);
    }
}
