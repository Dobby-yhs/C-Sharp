using System;

namespace Structure
{
    struct Point3D
    {
        public int X;
        public int Y;
        public int Z;

        public Point3D(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public override string ToString()  // System.Object 형식의 ToString() 메소드를 오버라이딩
        {
            return string.Format($"{X}, {Y}, {Z}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Point3D p3d1;  // 선언만으로도 인스턴스가 생성됩니다.
            p3d1.X = 10;
            p3d1.Y = 20;
            p3d1.Z = 40;

            Console.WriteLine(p3d1.ToString());

            Point3D p3d2 = new Point3D(100, 200, 300);  // 생성자를 이용한 인스턴스 생성도 가능합니다.
            Point3D p3d3 = p3d2;  // 구조체의 인스턴스를 다른 인스턴스에 할당하면 깊은 복사가 이루어집니다.
            p3d3.Z = 400;

            Console.WriteLine(p3d2.ToString());
            Console.WriteLine(p3d3.ToString()); 
        }
    }
}