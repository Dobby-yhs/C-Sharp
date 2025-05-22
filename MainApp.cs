using System;
using System.IO;
using FS = System.IO.FileStream;

namespace TextFile
{
    class MainApp
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter(new FS("a.txt", FileMode.Create)))
            {
                // Write()와 WriteLine() 메서드는
                // C#이 제공하는 모든 기본 데이터 형식에 대해 오버로딩되어 있습니다.
                sw.Write("Stream Write And Read");
                sw.WriteLine();
                sw.WriteLine(int.MaxValue);
                sw.WriteLine("GoodMoning!");
                sw.WriteLine(uint.MaxValue);
                sw.WriteLine("안녕하세요!");
                sw.WriteLine(double.MaxValue);
            }

            using StreamReader sr = new StreamReader(new FS("a.txt", FileMode.Open));
            {
                Console.WriteLine($"File size : {sr.BaseStream.Length} bytes");

                // EndOfStream 프로퍼티는 스트림의 끝에 도달했는지를 알려줍니다.
                while (sr.EndOfStream == false)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }
    }
}