using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace WithPython
{
    class MainApp
    {

        public static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("n", "홍길동");
            scope.SetVariable("p", "010-123-4567");

            // 파이썬 코드에서 클래스 선언
            ScriptSource source = engine.CreateScriptSourceFromString(
    @"
class NameCard :
    name = ''
    phone = ''

    def __init__(self, name, phone) :
        self.name = name
        self.phone = phone

    def printNameCard(self) :
        print (self.name + ', ' + self.phone)

NameCard(n, p)
");

            // 파이썬 코드를 실행하여 그 결과를 반환합니다.
            // NameCard() 생성자를 호출했으니 NameCard 객체가 생성되어 반환됩니다.
            dynamic result = source.Execute(scope);
            
            // result 객체의 메서드를 호출할 수도 있고, 필드에도 접근하는 것이 가능합니다.
            result.printNameCard();

            Console.WriteLine("{0}, {1}", result.name, result.phone);
        }
    }
}