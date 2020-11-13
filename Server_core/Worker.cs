using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.ConnectMessage;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private static WebSocketServer _server;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _server = new WebSocketServer("ws://127.0.0.1:7080");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                Task taskOne = RunTask(stoppingToken);
                await taskOne;
                
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            finally
            {
                
            }
        }

        protected Task RunTask(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                _server.AddWebSocketService<ClientMs> ("/ClientMs",()=>new ClientMs(_server));
                _server.AddWebSocketService<ServerMs> ("/ServerMs",()=>new ServerMs(_server));
                _server.Start ();
                _logger.LogInformation("server is starting");
                
            }, stoppingToken);
        }
    }

    public enum ConnetTag
    {
        Client,
        Server
    }
}