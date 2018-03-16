using System.Threading.Tasks;

namespace Core.Lib.Reactive
{

    public interface IServiceChannel<T> : IServiceChannel<T, T>
    {

    }
}
