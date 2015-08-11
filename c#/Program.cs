using System;
using System.Text;
using Chihank.Iso8583;
using Chihank.Iso8583Server.Responses;
using Chihank.Network;

namespace Chihank.Iso8583Server.Sample
{

    class Program
    {
        static void Main(string[] args)
        {
            var service = new Iso8583Service(3130, new MockDealService());
            // 记日志
            service.Logger = new ConsoleLogger();
            service.Tracker = new MyTracker();
            // 设置空闲断开链接时间
            service.IdleToCloseClient = TimeSpan.FromSeconds(10);
            // 设置持久化通信密钥存储
            service.TenantService = new MemoryTenantService();
            // 启动服务
            service.Start();

            Console.WriteLine("press any key to stop");
            Console.ReadKey();
            service.Stop();
        }
    }

    internal class MyTracker : ITracker
    {
        #region Implementation of ITracker

        public void Track(ResponseBase res, TradeType tradeType)
        {
            Console.WriteLine("Track: " + tradeType.ToString());
        }

        #endregion
    }

    internal class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteDebug(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteError(string message, Exception exception)
        {
            Console.WriteLine(message);
        }
    }
}
