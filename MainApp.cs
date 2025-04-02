using System;
using System.Reflection.Metadata.Ecma335;
using static System.Console;

namespace IntegralTypes
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int a = 123;
            object b = (object)a;  // a에 담긴 값을 박싱해서 힙에 저장
            int c = (int)b;        // b에 담긴 값을 언박싱해서 스택에 저장

            WriteLine(a);  // 123
            WriteLine(b);  // 123
            WriteLine(c);  // 123

            double x = 3.1414213;
            object y = x;          // x에 담긴 값을 박싱해서 힙에 저장
            double z = (double)y;  // y에 담긴 값을 언박싱해서 스택에 저장

            WriteLine(x);  // 3.1414213
            WriteLine(y);  // 3.1414213
            WriteLine(z);  // 3.1414213
        }
    }
}
 