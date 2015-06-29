using System;
using System.Text;
using Chihank.Iso8583;
using Chihank.Network;

namespace Chihank.Iso8583Server.Sample
{
    class Integer
    {
        public static int ValueOf(string text, int toBase)
        {
            return Convert.ToInt32(text, toBase);
        }

        public static string ToHexString(int i)
        {
            return i.ToString("x").ToLower();
        }

        public static string ToBinaryString(int value)
        {
            return Convert.ToString(value, 2).ToLower();
        }

        public static int ParseInt(string read)
        {
            return Convert.ToInt32(read);
        }
    }
    class Program
    {
        public static String Parse(String data)
        {

            var _length = 20;
            int len = Math.Min(data.Length, _length);
            String result = "";
            data = data.Substring(0, len);

            for (int i = 0; i < data.Length; i += 4)
            {
                String s = data.Substring(i, Math.Min(i + 4, data.Length) - i);
                s = s.PadRight(4, '0');
                result += Integer.ToHexString(Integer.ValueOf(s, 2));
            }

            int exceptedCount = (int)Math.Ceiling(_length / 8f) * 2;
            int actualCount = (int)Math.Ceiling(data.Length / 4f);

            if (actualCount < exceptedCount)
            {
                result += "".PadRight((exceptedCount - actualCount), '0');
            }
            return result;
        }
        static void Main(string[] args)
        {
//            Console.WriteLine(BitConverter.ToString(Encoding.GetEncoding("gb2312").GetBytes("本次返现金额共 10 元，返现比利(20%)")).Replace("-", ""));
//            return;
//            Console.WriteLine(Program.Parse("1101"));
//            return;
//            var d = BitConverter.ToString(Encoding.GetEncoding("gb2312").GetBytes("1"))
//                .Replace("-", "");
//            Console.WriteLine(d);
//            Console.WriteLine(d == "B1BEB4CEB7B5CFD6BDF0B6EEB9B220313020D4AAA3ACB7B5CFD6B1C8C0FB2832302529");
//            Console.WriteLine(Integer.ToBinaryString(2));
//            return;
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
