using System;

namespace Core.Lib.Reactive
{

    public interface IServiceBase<T>
    {
        void Complete();
        void Error(Exception ex);
        void Execute(T value);
    }
}
