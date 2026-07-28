//using System;
//using System.IO;
//using System.Threading.Tasks;

//namespace CSharp
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Board board = new Board();
//            Player player = new Player();

//            board.Initialize(25, player);
//            player.Initialize(1, 1, board);

//            Console.CursorVisible = false;  // Cursor의 Visible 상태

//            const int WAIT_TICK = 1000 / 30;

//            int lastTick = 0;

//            while (true)
//            {
//                #region 프레임 관리
//                int currentTick = System.Environment.TickCount;  // 절대적 시간 개념 x, 시스템이 시작된 이후의 밀리세컨드

//                // 만약에 경과한 시간이 1/30초보다 작다면, continue / 1초는 1000밀리 세컨드이기때문에 1000/30으로 계산
//                if (currentTick - lastTick < WAIT_TICK)
//                    continue;

//                int deltaTick = currentTick - lastTick;

//                lastTick = currentTick;  // 1/30초보다 크면 lastTick을 currentTick으로 변경
//                #endregion

//                // 입력

//                // 로직 - 데이터의 변환 부분
//                player.Update(deltaTick);

//                // 렌더링
//                Console.SetCursorPosition(0, 0);  // Cursor 위치 조정
//                board.Render();

//            }
//        }
//    }
//}
