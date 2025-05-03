using System;
using System.Collections;
using static System.Console;

namespace Yield
{
    class MyEnumerator
    {
        int[] numbers = { 1, 2, 3, 4 };

        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break;              // bield break는 GetEnumerator() 메서드를 종료시킵니다.
            yield return numbers[3];  // 따라서 이 코드는 실행되지 않습니다.
        }
    }  
   
    class MainApp
    {
        static void Main(string[] args)
        {
            var obj = new MyEnumerator();
            foreach (int i in obj)
            {
                Console.WriteLine(i);
            }
        }
    }
}