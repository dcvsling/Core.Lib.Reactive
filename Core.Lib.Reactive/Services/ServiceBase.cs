using System;
using System.Threading;

namespace Core.Lib.Reactive
{

    public abstract class ServiceBase<T> : IServiceBase<T>,IDisposable
    {
        private int isStopped;
        private IServiceBase<T> _this;
        protected ServiceBase()
        {
            _this =  this;
            isStopped = 0;
        }

        public virtual void Complete()
        {
        }
        public virtual void Error(Exception ex)
        {
        }
        public abstract void Execute(T value);
        
        void IServiceBase<T>.Complete()
        {
            if (Interlocked.Exchange(ref isStopped, 1) == 0)
            {
                try
                {
                    Complete();
                }
                finally
                {
                    Dispose();
                }
            }
        }
        void IServiceBase<T>.Error(Exception ex)
        {
            if (Interlocked.Exchange(ref isStopped, 1) == 0)
            {
                try
                {
                    Error(ex);
                }
                finally
                {
                    Dispose();
                }
            }
        }
        void IServiceBase<T>.Execute(T value)
        {
            try
            {
                if (Volatile.Read(ref isStopped) == 0)
                {
                    Execute(value);
                }
            }
            catch(Exception ex)
            {
                _this.Error(ex);
            }
        }
        #region IDisposable Support


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Volatile.Write(ref isStopped, 1);
            }
        }

        public void Dispose()
        {
            Dispose(true);  
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
