using System;

namespace MoreOnArray
{
    class MainApp
    { 
        private static bool CheckPassed(int score)
        {
            return score >= 60;
        }

        private static void Print(int value)
        {
            Console.Write($"{value} ");
        }

        static void Main(string[] args)
        {
            int[] scores = new int[] { 80, 74, 81, 90, 34 };

            foreach (int score in scores)
                Console.Write($"{score} ");
            Console.WriteLine();

            Array.Sort(scores);
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();


            Console.WriteLine($"Number of dimensions : {scores.Rank}");

            Console.WriteLine($"Binary Search : 81 is at "
                + $"{Array.BinarySearch<int>(scores, 81)}");

            Console.WriteLine($"Linear Search : 90 is at "
                + $"{Array.IndexOf<int>(scores, 90)}");

            Console.WriteLine($"Everyone passed ? : "
                + $"{Array.TrueForAll<int>(scores, CheckPassed)}");
            // CheckPassed : TrueForAll 메소드는 배열과 함께 조건을 검사하는 메소드를 매개변수로 받습니다.

            int index = Array.FindIndex<int>(scores, (score) => score < 60);
            // FindIndex : FindIndex 메소드는 특정 조건에 부합하는 메소드를 매개변수로 받습니다.
            // 해당 구문에서는 람다식으로 구현해봤습니다.

            scores[index] = 61;
            Console.WriteLine($"Everyone passed ? : "
                + $"{Array.TrueForAll<int>(scores, CheckPassed)}");

            Console.WriteLine("Old length of scores : " +
                $"{scores.GetLength(0)}");

            Array.Resize<int>(ref scores, 10);  // 5였던 배열의 용량을 10으로 재조정합니다.
            Console.WriteLine($"New length of scores : {scores.Length}");

            Array.ForEach<int>(scores, new Action<int>(Print)); // Action 대리자 사용
            Console.WriteLine();

            Array.Clear(scores, 3, 7);
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();

            int[] sliced = new int[3];
            Array.Copy(scores, 0, sliced, 0, 3);
            Array.ForEach<int>(sliced, new Action<int>(Print));
            Console.WriteLine();
        }
    }
}