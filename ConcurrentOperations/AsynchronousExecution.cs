using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcurrentOperations
{
    public static class AsynchronousExecution
    {
        public static async void AsynchronousRunWhenAll()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(Run());
            tasks.Add(Run());
            tasks.Add(Run());
            await Task.WhenAll(tasks.ToArray());
        }

        private static async Task Run()
        {
            int[] resultingArray = ArrayLookUp.LoopThrough();
            Console.WriteLine("Finished from AsynchronousExecution");
        }
    }
}
