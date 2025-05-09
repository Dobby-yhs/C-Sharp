using System;

namespace Delegate
{
    delegate int MyDelegate(int a, int b);

    class Calculator
    {
        public int Plus(int a, int b)  // 대리자는 인스턴스 메서드도 참조 가능합니다.
        {
            return a + b;
        }

        public static int Minus(int a, int b)  // 대리자는 정적 메서드도 참조 가능합니다.
        {
            return a - b;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            Console.WriteLine(Callback(3, 4));  // 메서드를 호출하듯 대리자를 사용하면, 참조하고 있는 메서드가 실행됩니다.

            Callback = new MyDelegate(Calculator.Minus);
            Console.WriteLine(Callback(7, 5));
        }
    }
}