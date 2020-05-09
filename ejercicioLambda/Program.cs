using System;
using System.Linq;

namespace Ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = SortInDescendingAndAbsoluteOrder(-1, 3, 5, 0, -2);
            PrintArray(array);
        }

        private static int[] SortInDescendingAndAbsoluteOrder(params int[] ints)
        {
            
            Array.Sort(ints, (a, b) => Math.Abs(a).CompareTo(Math.Abs(b)));
            Array.Reverse(ints);
            
            return ints;
        }

        private static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}