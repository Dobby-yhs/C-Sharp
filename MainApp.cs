using System;
using static System.Console;

namespace DivideRefOut
{
    class Divide
    {
        public static void DivideRef(int a, int b, ref int quotient, ref int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        public static void DivideOut(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            int a = 20, b = 3, c = 0, d = 0;

            Divide.DivideRef(a, b, ref c, ref d);

            Console.WriteLine("Quotient : {0}, Remainder {1}", c, d);

            int x = 20, y = 3, n, m;

            Divide.DivideOut(x, y, out n, out m);

            Console.WriteLine("Quotient : {0}, Remainder {1}", n, m);
        }
    }
}
