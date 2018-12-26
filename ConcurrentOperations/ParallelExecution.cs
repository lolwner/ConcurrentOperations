using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcurrentOperations
{
    public static class ParallelExecution
    {
        public static void ParallelRunInvoke()
        {
            try
            {
                Parallel.Invoke(
                    () => Run(),
                    () => Run(),
                    () => Run());
            }
            catch (AggregateException ex)
            {
                ex.Handle(exception =>
                {
                    return true;
                });
            }
        }

        private static void Run()
        {
            int[] resultingArray = ArrayLookUp.LoopThrough();
            Console.WriteLine("Finished from ParallelExecution");
        }
    }
}
