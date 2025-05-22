using System;
using System.IO;
using FS = System.IO.FileStream;

using static System.Console;

namespace BinaryFile
{
    class MainApp
    {
        static void Main(string[] args)
        {
            using (BinaryWriter bw = new BinaryWriter(new FS("a.dat", FileMode.Create)))
            {
                // BinaryWriter의 Wirte() 메서드는
                // C#이 제공하는 모든 기본 데이터 형식에 대해 오버로딩되어 있습니다.
                bw.Write(int.MaxValue);
                bw.Write("GoodMoning!");
                bw.Write(uint.MaxValue);
                bw.Write("안녕하세요!");
                bw.Write(double.MaxValue);
            }
            // bw 스트림은 위의 코드 블록을 통해 닫힙니다.
            // 만약 코드블록을 따로 지정해두지 않았더라면,
            // a.dat가 열려있는 상태에서 같은 파일을
            // 아래에서 다시 열려고 하는 상황이 발생했을 것입니다.

            using BinaryReader br = new BinaryReader(new FS("a.dat", FileMode.Open));

            // BinaryReader는 읽을 데이터 형식별로
            // Read데이터형식() 메서드를 제공합니다.
            WriteLine($"File size : {br.BaseStream.Length} bytes");
            WriteLine($"{br.ReadInt32()}");
            WriteLine($"{br.ReadString()}");
            WriteLine($"{br.ReadUInt32()}");
            WriteLine($"{br.ReadString()}");
            WriteLine($"{br.ReadDouble()}");
        }
    }
}