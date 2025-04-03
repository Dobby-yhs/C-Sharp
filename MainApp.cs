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

            //// 부동 소수점에서의 오버플로우와 언더플로우
            float maxSValue = 3.4e38f;
            float overflowMaxSResult = maxSValue * 2.0f;
            WriteLine("Result : {0}", overflowMaxSResult);
            // float의 양수 최대값에서 오버플로우 발생 -> Result : Infinity

            float minSValue = 1.4e-45f;
            float underflowMinSResult = minSValue / 10.0f;
            WriteLine("Result : {0}", underflowMinSResult);
            // float의 양수 최소값에서 언더 플로우 발생 -> Result : 0

            float maxUsValue = -3.4028235E+38f;
            float underflowMaxUsResult = maxUsValue - 1E+38f;
            WriteLine("Result : {0}", underflowMaxUsResult);
            // float의 음수 최대값에서 오버 플로우 발생 -> Result : -Infinity

            float minUsValue = 1.4e-45f;
            float underflowMinUsResult = minUsValue / 10.0f;
            WriteLine("Result : {0}", underflowMinUsResult);
            // float의 음수 최소값에서 언더 플로우 발생 -> Result : 0



            byte n1 = 255;
            byte m1 = 0;

            unchecked
            {
                n1++;  // overflow
                m1--;  // underflow
            }
            WriteLine("overflow : {0}", n1);
            WriteLine("underflow : {0}", m1);


            byte a1 = 255;
            byte b1 = 0;
            checked
            {
                a1++;  // overflow
                b1--;  // underflow
            }
            WriteLine("overflow : {0}", a1);
            WriteLine("underflow : {0}", b1);
        }
    }
}
 