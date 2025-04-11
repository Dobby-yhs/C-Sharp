using System;
using static System.Console;

namespace SwapBy
{
    class Swap
    {
        public static void RefSwap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        public static unsafe void PointerSwap(int* a, int* b)
        {
            int temp = *b;
            *b = *a;
            *a = temp;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            int x = 3;
            int y = 4;

            Swap.RefSwap(ref x, ref y);

            WriteLine($"x : {x}, y : {y}");

            unsafe 
            {
                Swap.PointerSwap(&x, &y);
            }

            WriteLine($"x : {x}, y : {y}");
        }
    }
}
