using System;
using System.Text.Json;
using Core.Models;

namespace Core.CallBacks
{
    public class SystemPropertiesCallBack<T> : ConnectionCallBack<JsonElement> where T : SystemProperties
    {
        public SystemPropertiesCallBack(Action<JsonElement> callBack) : base("systemProperties", callBack)
        {
        }
    }
}