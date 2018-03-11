using System.IO;
using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public static class ReactiveExtensions
    {
        public static IServiceClient<T> ToServiceClient<T>(this Func<T> func)
            => new StartOfServiceClient<T>(func);

        public static IServiceClient<T> ToServiceClient<T>(this Action<T> action)
            => new SimpleServiceClient<T>(_ => new DirectServiceChannel<T>().Run(action));
        
        public static IServiceClient<TOutput> Next<TInput, TOutput>(this IServiceClient<TInput> input, Func<TInput, TOutput> func)
            => new ServiceClient<TInput, TOutput>(input, func);

        public static IServiceClient<T> Do<T>(this IServiceClient<T> input, Action<T> action)
            => input.Next(action.ReturnSelf());

        public static Task Run<T>(this IServiceClient<T> input, Action<T> action)
            => input.Run(new Service<T>(action));

        public static IServiceClient<T> ToBaseClient<T>(this IServiceClient<T> client)
            => null;

        public static Func<T, T> ReturnSelf<T>(this Action<T> action)
            => t =>
            {
                action(t);
                return t;
            };
    }
}
