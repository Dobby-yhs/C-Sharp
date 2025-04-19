using System;
using System.Runtime.CompilerServices;
using MyExtension;  // 확장 메소드를 담는 클래스의 네임스페이스를 사용합니다.

namespace MyExtension
{
    public static class IntegerExtension
    {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }

        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for (int i = 1; i < exponent; i++)
                result = result * myInt;

            return result;
        }

        public static string Append(this string str, string input)
        {
            str += input;

            return str;
        }
    }
}

namespace ExtensionMethod
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"3^2 : {3.Square()}");
            Console.WriteLine($"3^4 : {3.Power(4)}");
            Console.WriteLine($"2^10 : {2.Power(10)}");

            string hello = "Hello";
            Console.WriteLine(hello.Append(", World!"));
        }
    }
}