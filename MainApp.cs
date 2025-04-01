using System;
using static System.Console;

namespace CSharp
{
    public class  MainApp
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("사용법 : CSharp.exe <이름>");
                return;
            }

            WriteLine("Hello, {0}!", args[0]);

        }
    }
}