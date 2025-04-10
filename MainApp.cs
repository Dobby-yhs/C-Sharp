using System;

namespace Goto
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Console.Write("종료 조건(숫자)을 입력하세요. : ");

            String input = Console.ReadLine();

            int input_number = Convert.ToInt32(input);

            int exit_number = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (exit_number++ == input_number)
                            goto EXIT_FOR;    // 조건이 참이면 EXIT_FOR 레이블로 이동합니다.

                        Console.WriteLine(exit_number);
                    }
                }
            }

            goto EXIT_PROGRAM;    // 위의 goto문이 실행되지 않으면, 해당 goto문에 따라 EXIT_PROGRAM 레이블로 이동합니다.

        EXIT_FOR:
            Console.WriteLine("\nExit nested for...");

        EXIT_PROGRAM:
            Console.WriteLine("Exit program...");
        }
    }
}
