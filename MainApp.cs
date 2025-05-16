using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace COMInterop
{
    class MainApp
    {
        public static void OldWay(string[, ] data, string savePath)
        {
            Excel.Application excelApp = new Excel.Application();

            excelApp.Workbooks.Add(Type.Missing);

            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            for(int i = 0; i < data.GetLength(0); i++)
            {
                ((Excel.Range)workSheet.Cells[i + 1, 1]).Value2 = data[i, 0];
                ((Excel.Range)workSheet.Cells[i + 1, 2]).Value2 = data[i, 1];
            }

            workSheet.SaveAs2(savePath + "\\shpark-book-old.xlsx",
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing);

            excelApp.Quit();
        }

        public static void NewWay(string[,] data, string savePath)
        {
            Excel.Application excelApp = new Excel.Application();

            excelApp.Workbooks.Add();

            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                workSheet.Cells[i + 1, 1] = data[i, 0];
                workSheet.Cells[i + 1, 2] = data[i, 1];
            }

            workSheet.SaveAs2(savePath + "\\shpark-book-dynamic.xlsx");

            excelApp.Quit();
        }

        static void Main(string[] args)
        {
            string savePath = System.IO.Directory.GetCurrentDirectory();
            string[,] array = new string[,]
            {
                { "좋은날", "2010" },
                { "밤편지", "2017" },
                { "팔레트", "2017" },
                { "Blueming", "2019" },
                { "에잇", "2020" },
                { "드라마", "2021" },
                { "라일락", "2021" },
                { "홀씨", "2024" },
                { "Love wins all", "2024" }
            };

            Console.WriteLine("Creating Excel document in old way...");
            OldWay(array, savePath);

            Console.WriteLine("Creating Excel document in new way...");
            NewWay(array, savePath);
        }
    }
}
