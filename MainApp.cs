using System;
using System.Collections;
using System.Drawing;
using System.Dynamic;

using static System.Console;

namespace ConstraintsOnTypeParameters
{
    public interface IPrintable
    { 
        void PrintInfo(IPrintable info);
    }

    class MyDocument : IPrintable
    {
        public void PrintInfo(IPrintable info)
        {
            WriteLine($"info's Type : {info.GetType().Name}");
        }
    }

    public static class Printer
    { 
        public static void PrintItem<T>(T item) where T : IPrintable
        {
            item.PrintInfo(item);
        }
    }

    class StructArray<T> where T : struct
    { 
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            WriteLine($"Creating StructArray<{typeof(T).Name}> with size {size}");
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            WriteLine($"Creating RefArray<{typeof(T).Name}> with size {size}");
            Array = new T[size];
        }
    }

    class Base { }
    class Derived : Base { }
    class BaseArray<A> where A : Base
    {
        public A[] Array { get; set; }
        public BaseArray(int size)
        {
            WriteLine($"Creating BaseArray<{typeof(A).Name}> with size {size}");
            Array = new A[size];
        }

        public void CopyArray<T>(T[] source) where T : A
        {
            WriteLine($"Calling BaseArray<{typeof(T).Name}>.CopyTo<{typeof(T).Name}>");
            source.CopyTo(Array, 0);
        }
    }


    class MainApp
    {
        public static T CreateInstance<T>() where T : new()
        {
            WriteLine($"Calling CreateInstance<{typeof(T).Name}>");
            return new T();
        }


        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;
            WriteLine();

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(1005);
            WriteLine();

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();
            WriteLine();

            BaseArray<Derived> d = new BaseArray<Derived>(3);
            d.Array[0] = new Derived();  // d.Array는 Derived[] 타입이기 때문에 Base 형식은 여기에 할당할 수 없습니다.
                                         // 할당이 가능한 것은 Derived 타입의 객체 또는 Derived를 상속받는 하위 타입의 객체만 가능합니다.
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();
            WriteLine();

            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyArray<Derived>(d.Array);
            WriteLine();

            MyDocument doc = new MyDocument();
            Printer.PrintItem(doc); 
            WriteLine();
        }
    }
}