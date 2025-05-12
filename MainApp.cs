using System;

namespace SimpleLambda
{
    class MainApp
    {
        delegate int Calculate(int a, int b);

        static void Main(string[] args)
        {
            Calculate calc_Method = delegate(int a, int b)
                                    { return a + b; };

            Console.WriteLine($"Calc_Anonymous Method : 3 + 4 = {calc_Method(3, 4)}");


            Calculate calc_Function = (a, b) => a + b;

            Console.WriteLine($"Calc_Anonymous Function : 3 + 4 =  {calc_Function(3, 4)}");
        }
    }
}