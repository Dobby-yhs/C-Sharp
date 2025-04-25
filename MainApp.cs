using System;

namespace InitOnly
{
    class Transaction
    {
        public string Form   { get; init; }
        public string To     { get; init; }
        public int    Amount { get; init; }

        public override string ToString()
        {
            return $"{Form,-10} -> {To,-10} : ${Amount}";
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Transaction tr1 = new Transaction { Form = "Alice", To = "Bob", Amount = 100 };
            Transaction tr2 = new Transaction { Form = "Bob", To = "Chalie", Amount = 50 };
            Transaction tr3 = new Transaction { Form = "Charlie", To = "Alice", Amount = 50 };

            // tr1.Amount = 30;  // 컴파일 에러 발생

            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
            Console.WriteLine(tr3);
        }
    }
}