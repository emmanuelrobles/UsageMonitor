using System;
using Core.Models;

namespace Core.CallBacks
{
    public class PingCallBack<T> : ConnectionCallBack<T>
    {
        public PingCallBack(Action<T> callBack) : base("ping", callBack)
        {
        }
    }
}