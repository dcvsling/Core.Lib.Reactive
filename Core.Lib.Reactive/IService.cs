namespace Core.Lib.Reactive
{

    public interface IService<T>
    {
        void Execute(T value);
    }
}
