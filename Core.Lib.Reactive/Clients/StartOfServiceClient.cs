using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{

    internal class StartOfServiceClient<TNext> : IServiceClient<TNext>
    {
        private readonly Func<TNext> _func;

        internal StartOfServiceClient(Func<TNext> func)
        {
            _func = func;
        }

        public Task Run(IService<TNext> service)
            => Task.Run(() => service.Execute(_func()));
    }
}
