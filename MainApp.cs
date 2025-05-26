using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace UsingTask
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string srcFile = args[0];

            // 파라미터를 전달하는 Action 대리자를 사용
            Action<object> FileCopyAction = (object state) =>
            {
                string[] paths = (String[])state;
                File.Copy(paths[0], paths[1]);

                Console.WriteLine("TaskID : {0}, ThreadId : {1}, {2} was copied to {3}",
                    Task.CurrentId, Thread.CurrentThread.ManagedThreadId, paths[0], paths[1]);
            };

            // 비동기로 파일 복사를 수행하는 Task 생성
            Task t1 = new Task(
                FileCopyAction, new string[] { srcFile, srcFile + ".copy1" });

            // 비동기로 파일 복사를 수행하는 Task 생성 및 실행
            Task t2 = Task.Run(() =>
            {
                FileCopyAction(new string[] { srcFile, srcFile + ".copy2" });
            });

            t1.Start();

            // 동기로 파일 복사를 수행하는 Task 생성
            Task t3 = new Task(
                FileCopyAction, new string[] { srcFile, srcFile + ".copy3" });

            // 동기 실행을 위한 RunSynchronously() 메서드
            t3.RunSynchronously();

            t1.Wait();
            t2.Wait();
            t3.Wait();
        }
    }
}
