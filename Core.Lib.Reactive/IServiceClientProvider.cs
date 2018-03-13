using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{

    internal interface IServiceClientProvider<T>
    {
        IServiceClient<TNext> Create<TNext>(Func<T, TNext> func);
    }
}
