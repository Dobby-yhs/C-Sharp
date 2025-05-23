using System;
using System.Threading;

namespace AbortingThread
{
    class SideTask
    {
        int count;
        CancellationToken cancellationToken;  // 취소 토큰

        public SideTask(int count, CancellationToken token) // 취소 토큰을 매개변수로 받음
        {
            this.count = count;
            this.cancellationToken = token;  // 취소 토큰 저장
        }

        public void KeepAlive()
        {
            try
            {
                while (count > 0)
                {
                    // 취소 요청 확인
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("취소 요청 받음. 스레드 종료 중...");
                        // cancellationToken.ThrowIfCancellationRequested();
                        // 예외를 던져서 종료 (선택 사항)
                        return;  // 메서드를 빠져나가 스레드 종료
                    }

                    Console.WriteLine($"{count--} left");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            // 취소 토큰 소스 생성
            CancellationTokenSource cts = new CancellationTokenSource();
            // 취소 토큰 얻기
            CancellationToken token = cts.Token;

            SideTask task = new SideTask(100, token); // 취소 토큰 전달
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;

            Console.WriteLine("Starting thread...");
            t1.Start();

            Thread.Sleep(100);

            Console.WriteLine("Requesting cancellation...");
            cts.Cancel(); // 취소 요청


            Console.WriteLine("Waiting until thread stops...");
            t1.Join();

            Console.WriteLine("Finished");
        }
    }
}
