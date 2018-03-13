using System.IO;
using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{

    public static class Chain
    {   
        public static IServiceChannel<T> From<T>(Action<T> action)
            => action.ToChannel();
        public static IServiceChannel<T> From<T>()
            => From<T>(_ => { });
    }
}
