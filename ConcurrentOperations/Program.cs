using System;
using System.Diagnostics;

namespace ConcurrentOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch asynchronousTimer = new Stopwatch();
            asynchronousTimer.Start();
            AsynchronousExecution.AsynchronousRunWhenAll();
            asynchronousTimer.Stop();
            Console.WriteLine($"Asynchronous call took {asynchronousTimer.Elapsed.TotalMilliseconds} ms");

            Stopwatch parallelTimer = new Stopwatch();
            parallelTimer.Start();
            ParallelExecution.ParallelRunInvoke();
            parallelTimer.Stop();
            Console.WriteLine($"Parallel call took {parallelTimer.Elapsed.TotalMilliseconds} ms");


            ThreadExecution.ThreadPoolRun();


            Console.ReadKey();
        }
    }
}
