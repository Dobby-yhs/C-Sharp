using System;

namespace DerivedInterface
{
    interface ILogger
    {
        void WriteLog(string message);
    }

    // IFormattableLogger는 ILogger를 상속합니다.
    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params Object[] args);
    }

    // ConsoleLogger는 IFormattableLogger를 상속합니다.
    class ConsoleLogger : IFormattableLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }

        public void WriteLog(string format, params Object[] args)
        {
            String message = String.Format(format, args);
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            IFormattableLogger logger = new ConsoleLogger();
            logger.WriteLog("The world is not flat.");
            logger.WriteLog("{0} + {1} = {2}", 1, 1, 2);
        }
    }
}