using System;

namespace TypeCasting
{
    class Mammal
    {
        public void Nurse()
        {
            Console.WriteLine("Nurse()");
        }
    }

    class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("Bark()");
        }
    }

    class Cat : Mammal
    {
        public void Meow()
        {
            Console.WriteLine("Meow()");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Mammal mammal = new Dog();
            Dog dog;

            if (mammal is Dog)  // is 연산자를 사용하여 타입 검사 수행
            {
                dog = (Dog)mammal;  // 명시적 형 변환(casting)으로 Mammal 타입의 mammal 객체를 Dog 타입으로 변환합니다. 
                                    // 이전에 is 연산자를 통해 mammal이 Dog 타입임을 확인했기 때문에 안전합니다.
                dog.Bark();
            }

            Mammal mammal2 = new Cat();

            Cat cat = mammal2 as Cat;  // as 연산자를 사용하여 형 변환
            if (cat != null)
            {
                cat.Meow();
            }

            Cat cat2 = mammal as Cat;  // as 연산자를 사용하여 mammal 객체를 Cat 타입으로 변환 시도합니다. 
                                       // 만약 변환이 불가능하면 null이 반환됩니다.

            if (cat2 != null)
            {
                cat2.Meow();
            }
            else
            {
                Console.WriteLine("cat2 is not a Cat");
            }
        }
    }
}