using System;

namespace Tuple
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 명명되지 않은 튜플
            var a = ("철수", 10);
            Console.WriteLine($"{a.Item1}, {a.Item2}");

            // 명명된 튜플
            var b = (Name : "영수", Age: 20);
            Console.WriteLine($"{b.Name}, {b.Age}");

            // 분해 1
            var (name, age) = b;
            Console.WriteLine($"{name} {age}");

            // 분해 2
            var (name2, age2) = ("민수", 30);
            Console.WriteLine($"{name2}, {age2}");

            // 분해 3
            (var name3, var age3) = a;
            Console.WriteLine($"{name3} {age3}");

            // 명명된 튜플 = 명명되지 않은 튜플
            b = a;
            Console.WriteLine($"{b.Name}, {b.Age}");
        }
         
    }
}