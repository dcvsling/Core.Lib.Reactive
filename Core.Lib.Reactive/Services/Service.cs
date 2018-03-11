using System;

namespace Core.Lib.Reactive
{
    public class Service<T, TNext> : IService<T>
    {
        private readonly Func<T,TNext> _func;
        private readonly IService<TNext> _output;

        public Service(IService<TNext> output,Func<T,TNext> func)
        {
            _func = func;
            _output = output;
        }


        public void Execute(T value)
            => _output.Execute(_func(value));
    }
}
