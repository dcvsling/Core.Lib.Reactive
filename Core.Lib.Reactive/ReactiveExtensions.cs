using System.Runtime.InteropServices;
using System.IO;
using System;
using System.Threading.Tasks;

namespace Core.Lib.Reactive
{
    public static class ReactiveExtensions
    {
        public static IServiceChannel<T> ToChannel<T>(this Action<T> action)
            => new DirectServiceChannel<T>(action);

        public static IServiceChannel<T> ToChannel<T>(this IService<T> service)
            => new DirectServiceChannel<T>(service.Execute);

        public static IServiceClient<TOutput> Next<TInput, TOutput>(this IServiceClient<TInput> input, Func<TInput, TOutput> func)
            => input.Create(func);
        public static IServiceClient<T> Do<T>(this IServiceClient<T> input, Action<T> action)
            => input.Create(t =>{ action(t); return t; });

        public static Task Run<T>(this IServiceClient<T> input, Action<T> action)
            => input.Run(new Service<T>(action));

        public static IServiceChannel<T, T> RegisterNotify<T>(this IServiceChannel<T> channel, IService<object> decorator)
            => new ServiceChannel<T, T>(channel,channel, decorator);
            
        public static IService<T> Decorate<T>(this IService<object> decorator, IService<T> service)
            => new Service<T, T>( 
                service, 
                t => {
                    decorator.Execute(t);
                    return t;
                });

        public static IService<T> Merge<T>(this IService<T> left, IService<T> right)
           => new Service<T>(
               t => {
                   left.Execute(t);
                   right.Execute(t);
               });

        private static IServiceClient<TNext> Create<T, TNext>(this IServiceClient<T> client, Func<T, TNext> func)
            => client is IServiceClientProvider<T> provider ? provider.Create(func) : new ServiceClient<T, TNext>(client, func, new Service<object>());
    }
}
