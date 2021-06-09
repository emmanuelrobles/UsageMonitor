using System;

namespace Core.Models
{
    public abstract class ConnectionCallBack<T>
    {
        public string Identifier { get; private set; }
        public Action<T> CallBack { get; private set; }

        protected ConnectionCallBack(string identifier, Action<T> callBack)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            CallBack = callBack ?? throw new ArgumentNullException(nameof(callBack));
        }
    }
}