using System;

class Base
{
    public virtual void SealMe() { }
}

class Derived : Base
{
    public sealed override void SealMe() { }
}

class WantToOverride : Derived
{
    public override void SealMe() { }  // 컴파일 에러 발생
}

class MainApp
{
    static void Main(string[] args)
    {

    }
}