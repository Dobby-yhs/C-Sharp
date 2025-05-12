using System;
using System.Collections.Generic;
using System.Threading;

namespace ExpressionBodiedMember
{
    class FriendList
    {
        private List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);  // list.Add() 메서드를 호출하는 식
        public void Remove(string name) => list.Remove(name);  // list.Remove() 메서드를 호출하는 식
        public void PrintAll()
        {
            foreach (var s in list)
                Console.WriteLine(s);
        }

        public FriendList() => Console.WriteLine("FriendList()");  // 생성자의 식 구현
        ~FriendList() => Console.WriteLine("~FriendList()");       // 소멸자의 식 구현 

        // public int Capacity => list.Capacity;  // 읽기 전용 속성의 식 구현 (get 키워드 생략)
        public int Capacity  // 속성의 식 구현
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }

        // public string this[int index] => list[index];  // 읽기 전용 인덱서의 식 구현(get 키워드 생략)
        public string this[int index]  // 인덱서의 식 구현
        {
            get => list[index];
            set => list[index] = value;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList();
            obj.Add("Eeny");
            obj.Add("Meeny");
            obj.Add("Miny");
            obj.Remove("Eeny");
            obj.PrintAll();

            Console.WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            Console.WriteLine($"{obj.Capacity}");

            Console.WriteLine($"{obj[0]}");
            obj[0] = "Moe";
            obj.PrintAll();
        }
    }
}