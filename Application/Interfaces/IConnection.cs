using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Application.Interfaces
{
    public interface IConnection<T>
    { 
        public Task RegisterCallBacksAsync(IEnumerable<ConnectionCallBack<T>> callBacks);
    }
}