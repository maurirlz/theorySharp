using System;

namespace ejercicioBruzzo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = InsertionSort(-1, 3, 5, 0, -2);

            int[] arregloDescendiente = InsertionSort(array);
            
            PrintArray(arregloDescendiente);
        }

        private static int[] InsertionSort(params int[] array)
        {
            for (int firstUnsortedIndex = 1; firstUnsortedIndex < array.Length; firstUnsortedIndex++)
            {
                int newElement = array[firstUnsortedIndex];
                int i;

                for (i = firstUnsortedIndex; i > 0 && (Math.Abs(array[i - 1]) < Math.Abs(newElement)); i--)
                {
                    array[i] = array[i - 1];
                }

                array[i] = newElement;
            }
            
            return array;
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