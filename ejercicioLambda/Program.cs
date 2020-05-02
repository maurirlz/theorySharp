using System;
using System.Linq;

namespace Ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = sortInDescendingAndAbsoluteOrder(-1, 3, 5, 0, -2);
            printArray(array);
        }

        private static int[] sortInDescendingAndAbsoluteOrder(params int[] ints)
        {
            
            Array.Sort(ints, (a, b) => Math.Abs(a).CompareTo(Math.Abs(b)));
            Array.Reverse(ints);
            
            return ints;
        }

        private static void printArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}