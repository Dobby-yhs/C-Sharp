using System;

namespace EX9_1
{
    class NameCard
    {
        public int Age { get; set; }
        public string Name { get; set; }

    }

    class MainApp
    {
        public static void Main()
        {
            NameCard MyCard = new NameCard()
            {
                Age = 20,
                Name = "길동"
            };

            Console.WriteLine("나이 : {0}", MyCard.Age);
            Console.WriteLine("이름 : {0}", MyCard.Name);
        }
    }
}