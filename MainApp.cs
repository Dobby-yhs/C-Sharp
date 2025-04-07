using System;
using static System.Console;

namespace ShiftOperator
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int a = 0xF0 | 0x0F;
            WriteLine($"{a}");
        }
    }
}