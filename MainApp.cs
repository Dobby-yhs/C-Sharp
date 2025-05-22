using System;
using System.IO;
using FS = System.IO.FileStream;


namespace ManualBinarySerialization
{
    class NameCard
    {
        public string Name;
        public string Phone;
        public int Age;

        public int HaveMoney;

        public NameCard() { }

        public NameCard(string name, string phone, int age)
        {
            Name = name;
            Phone = phone;
            Age = age;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            string binaryFilePath = "a.dat";

            NameCard originalNc = new NameCard("홍길동", "010-123-4567", 33);

            using (Stream fs = new FS(binaryFilePath, FileMode.Create))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(originalNc.Name);
                bw.Write(originalNc.Phone);
                bw.Write(originalNc.Age);

                Console.WriteLine($"'{binaryFilePath}'에 이진 직렬화 완료.");
            }

            using (Stream fs = new FS(binaryFilePath, FileMode.Open))
            using (BinaryReader br = new BinaryReader(fs))
            {
                NameCard deserializedNc = new NameCard();

                deserializedNc.Name = br.ReadString();
                deserializedNc.Phone = br.ReadString();
                deserializedNc.Age = br.ReadInt32();

                Console.WriteLine($"'{binaryFilePath}'에서 이진 역직렬화 완료.");
                Console.WriteLine($"Name : {deserializedNc.Name}");
                Console.WriteLine($"Phone : {deserializedNc.Phone}");
                Console.WriteLine($"Age : {deserializedNc.Age}");
            }
        }
    }
}