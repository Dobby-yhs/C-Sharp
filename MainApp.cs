using System;
using static System.Console;

namespace Practice_No3
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int i = 1; // 행 번호

            do
            {
                int j = 1; // 내부 반복을 위한 변수 초기화
                do
                {
                    Console.Write("*"); // 별 출력
                    j++; // 내부 반복 변수 증가
                } while (j <= i); // 현재 행 수에 따라 반복

                Console.WriteLine(); // 다음 행으로 이동
                i++; // 행 번호 증가
            } while (i <= 5); // 5행까지 반복
        }
    }
}
