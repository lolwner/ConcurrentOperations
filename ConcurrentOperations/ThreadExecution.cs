using System;
using System.Diagnostics;
using System.Threading;
using System.Security.Permissions;

namespace ConcurrentOperations
{
    public static class ThreadExecution
    {
        public static double elapsedTimeInMs;

        public static void ThreadPoolRun()
        {
            WaitHandle[] waitHandles = new WaitHandle[]
            {
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false)
            };
            var threadTimer = new Stopwatch();
            threadTimer.Start();
            for (int i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Run), waitHandles[i]);
            }
            WaitHandle.WaitAll(waitHandles);
            threadTimer.Stop();

            Console.WriteLine($"Finished from ThreadExecution2 took {threadTimer.Elapsed.TotalMilliseconds} ms");
        }

        private static void Run(object state)
        {
            int[] resultingArray = ArrayLookUp.LoopThrough();
            Console.WriteLine($"Finished from ThreadExecution");
            AutoResetEvent waitHandle = (AutoResetEvent)state;
            waitHandle.Set();
        }
    }
}
