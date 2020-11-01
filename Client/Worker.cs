using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebSocketSharp;

namespace FinalController
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string url;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            url = "ws://127.0.0.1:7080/ClientMs";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                Task taskOne = RunTaskOne(stoppingToken);

                //await Task.WhenAll(taskOne, taskTwo, taskThree);
                await taskOne;//使用await关键字，异步等待RunTaskOne、RunTaskTwo、RunTaskThree方法返回的三个Task对象完成，这样调用ExecuteAsync方法的线程会立即返回，不会卡在这里被阻塞
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            finally
            {
               // _logger.LogInformation("Worker stop!!!!!");
                //Worker Service服务停止后，如果有需要收尾的逻辑，可以写在这里
            }
        }

        protected Task RunTaskOne(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                StringBuilder ip = new StringBuilder();
                for (int i = 255; i > 1; i--)
                {
                    ip.Clear();
                    ip.Append("192.168.1.").Append(i);
                    if (PingIp(ip.ToString()))
                    {
                        //TODO 处理iP
                        break;
                    }
                }
                
                WebSocket ws = new WebSocket(url);
                ws.OnMessage += (sender, e) =>
                {
                    _logger.LogInformation(String.Format("[server]{0}",e.Data));
                    if (e.Data.Contains("exit"))
                    {
                        ws.Close();
                        _logger.LogInformation("client is stop");
                    }
                };
                StringBuilder sb = new StringBuilder();

                ws.Connect ();
                

            }, stoppingToken);
        }

        private bool PingIp(string strIP)
        {
            bool bRet = false;
            try
            {
                Ping pingSend = new Ping();
                PingReply reply = pingSend.Send(strIP, 100);
                if (reply.Status == IPStatus.Success)
                    bRet = true;
            }
            catch (Exception e)
            {
                bRet = false;
                Console.WriteLine(e.Message);
            }

            return bRet;
        }

    }
}