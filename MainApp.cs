using System;

namespace PropertiesInInterface
{
    interface INamedValue
    {
        // 자동 구현 프로퍼티처럼 구현이 없지만, C# 컴파일러는 인터페이스의 프로퍼티에 대해서는 자동으로 구현해주지 않습니다.
        // 인터페이스는 어떤 구현도 가지지 않기 때문입니다.
        string Name
        {
            get;
            set;
        }

        string Value
        {
            get;
            set;
        }
    }

    // INamedValue 인터페이스를 상속하는 NamedValue 클래스는 반드시 Name과 Value를 구현해야 합니다.
    // 이때는 자동 구현 프로퍼티를 이용하는 것도 가능합니다.
    class NamedValue : INamedValue
    {
        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            NamedValue name = new NamedValue() { Name = "이름", Value = "홍길동" };

            NamedValue height = new NamedValue() { Name = "키", Value = "182cm" };

            NamedValue width = new NamedValue() { Name = "몸무게", Value = "90kg" };

            Console.WriteLine($"{name.Name} : {name.Value}");
            Console.WriteLine($"{height.Name} : {height.Value}");
            Console.WriteLine($"{width.Name} : {width.Value}");
        }
    }
}