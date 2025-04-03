using System;
using static System.Console;

namespace StringSlice
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string greeting = "Hello  World";
            string[] arr1 = greeting.Split(new string[] { " " }, StringSplitOptions.None);
            // arr1: ["Hello", "", "World"]
            foreach (string element in arr1)
                WriteLine("{0}", element);

            WriteLine();
            WriteLine();

            string[] arr2 = greeting.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            // arr2: ["Hello", "World"]
            foreach (string element in arr2)
                WriteLine("{0}", element);

            WriteLine();
            WriteLine();

            string testString = "aaVaaaVVaaaa";
            string[] arr3 = testString.Split(new string[] {"V"}, StringSplitOptions.None);
            foreach (string element in arr3)
                WriteLine("{0}", element);

            WriteLine();
            WriteLine();

            string[] arr4 = testString.Split(new string[] { "V" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string element in arr4)
                WriteLine("{0}", element);

            WriteLine();
            WriteLine();

            string[] arr5 = testString.Split(new string[] { "bb" }, StringSplitOptions.None);
            foreach (string element in arr5)
                WriteLine("{0}", element);

            WriteLine();
            WriteLine();

            string[] arr6 = testString.Split("b", StringSplitOptions.None);
            foreach (string element in arr6)
                WriteLine("{0}", element);

            WriteLine();
            WriteLine();

            string[] arr7 = testString.Split("V");
            foreach (string element in arr7)
                WriteLine("{0}", element);

        }
    }
}