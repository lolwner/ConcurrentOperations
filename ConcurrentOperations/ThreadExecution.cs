using System;
using System.Threading;

namespace ConcurrentOperations
{
    public static class ThreadExecution
    {
        public static void ThreadPoolRun()
        {
            for (int i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem(Run);
            }

        }

        private static void Run(object state)
        {
            int[] resultingArray = ArrayLookUp.LoopThrough();
            Console.WriteLine("Finished from ThreadExecution");
        }
    }
}
