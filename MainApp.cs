using System;
using static System.Console;

namespace Switch
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int input = Convert.ToInt32(Console.ReadLine());

            // 1의 자리를 버립니다.  예) 92 -> 90, 87 -> 80
            int score = (int)(Math.Truncate(input / 10.0) * 10);

            string grade = score switch
            {
                90 => "A",
                80 => "B",
                70 => "C",
                60 => "D",
                _  => "F"
            };

            WriteLine($"{grade}");
        }
    }
}