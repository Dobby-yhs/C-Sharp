using System;
using System.Reflection;
using System.Reflection.Emit;

namespace EmitTest
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // Code A
            // Create Assembly
            AssemblyBuilder newAssembly = 
                AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName("CalculatorAssembly"),
                AssemblyBuilderAccess.Run);

            // Code B
            // Create Module
            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");

            // Code C
            // Create Class
            TypeBuilder newType = newModule.DefineType("Sum1To100");

            // Code D
            // Create Method 
            MethodBuilder newMethod = newType.DefineMethod(
                "Calculate",
                MethodAttributes.Public,
                typeof(int),    // 반환 형식
                new Type[0]);   // 매개변수

            // Code E
            // Create IL Commands to by executed by the method
            ILGenerator generator = newMethod.GetILGenerator();

            generator.Emit(OpCodes.Ldc_I4, 1);

            for (int i = 2; i <= 100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Add);
            }

            generator.Emit(OpCodes.Ret);

            // Sum1To100 Class Emit to CLR
            newType.CreateType();

            // Generate Dynamic Instance of new type
            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculate");
            Console.WriteLine(Calculate.Invoke(sum1To100, null));
        }
    }
}
