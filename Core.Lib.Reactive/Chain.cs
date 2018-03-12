using System.IO;
using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{

    public static class Chain
    {
        public static IServiceClient<T> FromGetter<T>(Func<T> factory)
            => factory.ToServiceClient();
        
        public static IServiceChannel<T> FromAction<T>(Action<T> action)
            => action.ToServiceChannel();
    }
}
