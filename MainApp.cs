using System;
using static System.Console;

class Global
{
    public static int Count = 0;
}

class ClassA
{
    public static void PlusA()
    {
        Global.Count++;
    }
}

class ClassB
{
    public static void PlusB()
    {
        Global.Count++;
    }
}

class MainApp
{
    static void Main()
    {
        WriteLine($"Global.Count : {Global.Count}");
        // 인스턴스를 생성하지 않고 클래스의 이름을 통해 필드에 직접 접근합니다.

        ClassA.PlusA();  // 인스턴스를 생성하지 않고 클래스의 메소드에 직접 접근합니다.
        ClassA.PlusA();  // ""
        ClassB.PlusB();  // ""
        ClassB.PlusB();  // ""

        WriteLine($"Global.Count : {Global.Count}");
    }
}