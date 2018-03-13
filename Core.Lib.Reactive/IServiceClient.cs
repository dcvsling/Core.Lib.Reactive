using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public interface IServiceClient<T>
    {
        Task Run(IService<T> service);
    }
}
