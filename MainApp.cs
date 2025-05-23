using System;
using System.Threading;

namespace UsingThreadState
{
    class MainApp
    {
        private static void PrintThreadState(ThreadState state)
        {
            Console.WriteLine("{0, -16} : {1}", state, (int)state);
        }

        static void Main(string[] args)
        {
            PrintThreadState(ThreadState.Running);                        // 000000000
                                                                          
            PrintThreadState(ThreadState.StopRequested);                  // 000000001
                                                                          
            PrintThreadState(ThreadState.SuspendRequested);               // 000000010
                                                                          
            PrintThreadState(ThreadState.Background);                     // 000000100
                                                                          
            PrintThreadState(ThreadState.Unstarted);                      // 000001000
                                                                          
            PrintThreadState(ThreadState.Stopped);                        // 000010000
                                                                          
            PrintThreadState(ThreadState.WaitSleepJoin);                  // 000100000
                                                                          
            PrintThreadState(ThreadState.Suspended);                      // 001000000
                                                                          
            PrintThreadState(ThreadState.AbortRequested);                 // 010000000
                                                                          
            PrintThreadState(ThreadState.Aborted);                        // 100000000

            PrintThreadState(ThreadState.Aborted | ThreadState.Stopped);  // 100010000
        }
    }
}
