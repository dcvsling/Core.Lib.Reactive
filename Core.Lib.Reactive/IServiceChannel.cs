using System.Threading.Tasks;

namespace Core.Lib.Reactive
{

    public interface IServiceChannel<TInput,TOutput> : IService<TInput>, IServiceClient<TOutput>
    {

    }
}
