using System;
using Chihank.Network;

namespace Chihank.Iso8583Server.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 监听端口 3130
            var service = new Iso8583Service(3131, new MockDealService());
            // 记日志
            service.Logger = new ConsoleLogger();
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
