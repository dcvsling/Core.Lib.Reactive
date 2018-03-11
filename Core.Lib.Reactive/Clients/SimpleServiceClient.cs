using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    internal class SimpleServiceClient<T> : IServiceClient<T>
    {
        private readonly Func<IService<T>, Task> _task;
        
        protected internal SimpleServiceClient(Func<IService<T>,Task> task)
        {
            _task = task;
        }
        
        public Task Run(IService<T> service)
            => _task(service);
    }
}
