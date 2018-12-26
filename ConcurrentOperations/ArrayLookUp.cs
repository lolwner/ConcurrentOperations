using System;

namespace ConcurrentOperations
{
    public static class ArrayLookUp
    {
        public static int[] LoopThrough()
        {
            int[] array = new int[5000];
            Random randomGenerator = new Random();
            for (int iterator = 0; iterator < array.Length; iterator++)
            {
                array[iterator] = iterator;
            }
            return array;
        }
    }
}
