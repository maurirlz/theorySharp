using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] intArray = new int[10];
            
            Random random = new Random();

            for (int i = 0; i < intArray.Length; i++)
            {

                intArray[i] = random.Next(10);
            }

            var numerosMayoresA5 =
                from item in intArray
                where item > 5
                select item;

            var numerosMenoresA5 =
                from item in intArray
                where item < 5
                select item;


            var numerosANumerosA8 =
                from item in intArray
                where item > 8
                select item;
            
            foreach (int i in numerosMayoresA5)
            {
                Console.WriteLine(i);
            }
        }
    }
}