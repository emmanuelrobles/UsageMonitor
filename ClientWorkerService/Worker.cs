using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Core.CallBacks;
using Core.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SocketClient;

namespace ClientWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var sc = new SocketConnection("http://localhost:5000", 4);

            await sc.RegisterCallBacksAsync(new[] { new SystemPropertiesCallBack<SystemProperties>(s =>
            {
                var data = JsonSerializer.Deserialize<SystemProperties>(s.GetRawText());
                _logger.LogInformation("data: {@data}", JsonSerializer.Serialize(data));
            })});
            
            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    await Task.Delay(1000, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
    }
}