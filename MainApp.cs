using System;
using System.Reflection.Metadata.Ecma335;
using static System.Console;

namespace FloatConversion
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 크기가 서로 다른 부동 소수점 형식 사이의 변환
            float a = 69.6875f;
            WriteLine("a : {0}", a);  // a : 69.6575

            double b = (double)a;
            WriteLine("b : {0}", b);  // b : 69.6875
            WriteLine("69.6875 == b : {0}", 69.6875 == b); // 69.6875 == b : True

            float x = 0.1f;
            WriteLine("x : {0}", x);  // x : 0.1

            double y = (double)x;
            WriteLine("y : {0}", y);  // y : 0.10000000149011612
            WriteLine("0.1 == y : {0}", 0.1 == y);  // 0.1 == y : False

            double n = 3.141592653589793238d;
            WriteLine("n : {0}", n);  // n : 3.1415926535897934
            
            float  m = (float)n;
            WriteLine("m : {0}", m);  // m : 3.1415927
            WriteLine("3.141592653589793238 == m : {0}", 3.141592653589793238 == m);
                // 3.141592653589793228 == m : False

            // 부동 소수점에서의 오버플로우와 언더플로우
            float largeValue = 3.4e38f;
            float overflowResult = largeValue * 2.0f;
            WriteLine("Result : {0}", overflowResult);
                // 오버플로우 발생 -> Result : Infinity

            float smallValue = 1.4e-45f;
            float underflowResult = smallValue / 10.0f;
            WriteLine("Result : {0}", underflowResult);
                // 언더 플로우 발생 -> Result : 0
            
        }
    }
}
 