using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace GetTypeExample
{
    interface TypeValue
    {
        public int Value { get; set; }
        event EventHandler ValueChanged;
    }

    class Typetest : TypeValue
    {
        private int[] array;
        public static readonly string AppName = "MyTestApp";

        public string Name { get; set; }
        public int Value { get; set; }

        public event EventHandler ValueChanged;

        public event EventHandler MyStatusEvent;

        public Typetest()
        {
            array = new int[5];
        }

        public Typetest(string name) : this()
        {
            this.Name = name;
        }

        public int ReturnFirstIndex(int[] arr)
        {
            if (array != null && array.Length > 0)
                return array[0];
            return -1;
        }

        public static string GetAppName()
        {
            return AppName;
        }

        public class PublicNestedClass { }
        private class PrivateNestedClass { }
        protected struct ProtectedNestedStruct { }
        internal enum InternalNestedEnum { A, B, C }
    }


    class MainApp
    {
        static void PrintInterfaces(Type type)
        {
            Console.WriteLine("-------- Interfaces --------");

            Type[] interfaces = type.GetInterfaces();
            foreach (Type i in interfaces)
                Console.WriteLine("Name : {0}", i.Name);

            Console.WriteLine();
        }

        static void PrintFields(Type type)
        {
            Console.WriteLine("-------- Fields --------");

            FieldInfo[] fields = type.GetFields(
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                String accessLevel = "protected";
                if (field.IsPublic) accessLevel = "public";
                else if (field.IsPrivate) accessLevel = "private";

                Console.WriteLine("Access : {0}, Type : {1}, Name : {2}",
                    accessLevel, field.FieldType.Name, field.Name);
            }

            Console.WriteLine();
        }

        static void PrintMethods(Type type)
        {
            Console.WriteLine("-------- Methods --------");

            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.Write("Type : {0}, Name : {1}, Parameter : ",
                    method.ReturnType.Name, method.Name);

                ParameterInfo[] args = method.GetParameters();
                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write("{0}", args[i].ParameterType.Name);
                    if (i < args.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintProperties(Type type)
        {
            Console.WriteLine("-------- Properties --------");

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
                Console.WriteLine("Type : {0}, Name : {1}",
                    property.PropertyType.Name, property.Name);

            Console.WriteLine();
        }

        static void PrintConstructors(Type type)
        {
            Console.WriteLine("-------- Constructors --------");

            ConstructorInfo[] constructorInfos = type.GetConstructors(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (ConstructorInfo constructor in constructorInfos)
            {
                String accessLevel = "protected";
                if (constructor.IsPublic) accessLevel = "public";
                else if (constructor.IsPrivate) accessLevel = "private";

                Console.WriteLine("Access : {0}, Name : {1}, Parameters : ",
                    accessLevel, constructor.Name);

                ParameterInfo[] args = constructor.GetParameters();
                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write("{0}", args[i].ParameterType.Name);
                    if (i < args.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintNestedTypes(Type type)
        {
            Console.WriteLine("-------- Nested Types --------");
            Type[] nestedTypes = type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);

            foreach (Type nestedType in nestedTypes)
            {
                string visibility = "???";
                if (nestedType.IsNestedPublic) visibility = "public";
                else if (nestedType.IsNestedPrivate) visibility = "private";
                else if (nestedType.IsNestedFamily) visibility = "protected";
                else if (nestedType.IsNestedAssembly) visibility = "internal";
                else if (nestedType.IsNestedFamANDAssem) visibility = "private protected";
                else if (nestedType.IsNestedFamORAssem) visibility = "protected internal";


                Console.WriteLine("Visibility : {0}, Name : {1}, BaseType: {2}",
                    visibility, nestedType.Name, nestedType.BaseType.Name);
            }
            Console.WriteLine();
        }

        static void PrintEvents(Type type)
        {
            Console.WriteLine("-------- Events --------");
            EventInfo[] events = type.GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (EventInfo eventInfo in events)
            {
                Console.WriteLine("Name : {0}, Handler Type : {1}",
                    eventInfo.Name, eventInfo.EventHandlerType.Name);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Typetest typetest = new Typetest();
            Type type = typetest.GetType();

            PrintInterfaces(type);
            PrintFields(type);
            PrintProperties(type);
            PrintMethods(type);
            PrintConstructors(type);
            PrintNestedTypes(type);
            PrintEvents(type);
        }
    }
}
