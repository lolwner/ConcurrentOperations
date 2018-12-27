using System;
using System.Diagnostics;
using System.Threading;

namespace ConcurrentOperations
{
    public static class ThreadExecution
    {
        public static double elapsedTimeInMs;
        private static Stopwatch threadTimer;

        static ThreadExecution()
        {
            threadTimer = new Stopwatch();
        }

        public static void ThreadPoolRun()
        {
            for (int i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem(Run);
            }
        }

        private static void Run(object state)
        {
            if (threadTimer.IsRunning)
            {
                threadTimer.Stop();
            }

            threadTimer.Start();
            int[] resultingArray = ArrayLookUp.LoopThrough();
            threadTimer.Stop();
            elapsedTimeInMs = elapsedTimeInMs + threadTimer.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Finished from ThreadExecution took {elapsedTimeInMs} ms");
            
        }
    }
}
