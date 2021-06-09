using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Interfaces;
using Core.Models;
using SocketIOClient;

namespace SocketClient
{
    public class SocketConnection : IConnection<JsonElement>
    {
        private SocketIO client;

        public SocketConnection(string url, int engineIoVersion)
        {
            client = new SocketIO(url, new SocketIOOptions(){EIO = engineIoVersion});
        }

        public Task RegisterCallBacksAsync(IEnumerable<ConnectionCallBack<JsonElement>> callBacks)
        {
            foreach (var connectionCallBack in callBacks)
            {
                client.On(connectionCallBack.Identifier, response =>
                {
                    connectionCallBack.CallBack(response.GetValue());
                });
            }

            return client.ConnectAsync();
        }
    }
}