using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio3
{
    class Program

    {
        public const int People = 10;
        
        static void Main(string[] args)
        {
            
            /*
             * Objetivo: Comprender el uso basico de estructuras repetitivas.
             * ejercicioLambda:
             *     - Calcular la media y desviacion estandar de un conjunto de 10 personas.
             *     - Tome por teclado la altura en cm de cada persona y carguela a un arreglo.
             *     - Presente los resultados obtenidos.
             *     - Muestre que alturas se encuentran por encima de la media y por debajo de ella.
             *     - Muestre que alturas se encuentran dentro del rango definido por la desviacion estandar.
             */

            decimal[] heights = new decimal[People];

            heights = GetHeights(heights);
            PrintArray(heights);
            
            decimal average = GetAverage(heights);
            decimal standardDeviation = GetStandardDeviation(average, heights);

            var belowAverage =
                from height in heights
                where height < average
                select height;

            var aboveAverage =
                from height in heights
                where height >= average
                select height;

            var inRangeBetweenDeviation =
                from height in heights
                where Math.Abs(height - average) <= standardDeviation
                select height;

            Console.WriteLine("Heights equal to or above the average height in heights: ");
            PrintEnumValues(aboveAverage);

            Console.WriteLine();
            Console.WriteLine("Heights below to the average height in heights: ");
            PrintEnumValues(belowAverage);

            Console.WriteLine();
            Console.WriteLine($"Heights between the range of 0 and {standardDeviation}");
            PrintEnumValues(inRangeBetweenDeviation);
        }

        private static decimal[] GetHeights(decimal[] arrayOfHeights)
        {

            for (int i = 0; i < People; i++)
            {
                Console.WriteLine("Input a height (in centimeters): ");
                arrayOfHeights[i] = Convert.ToDecimal(Console.Read());
                Console.WriteLine();
            }

            return arrayOfHeights;
        }

        private static void PrintArray(decimal[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}, ");
            }
        }

        private static decimal GetAverage(decimal[] array)
        {
            decimal avg = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                avg += array[i];
            }

            return avg / array.Length;
        }

        private static decimal GetStandardDeviation(decimal average, decimal[] arrayOfData)
        {

            decimal[] arrayOfDeviation = new decimal[arrayOfData.Length];
            decimal total = 0;

            for (int i = 0; i < arrayOfData.Length; i++)
            {
                double firstDeviation = (double) arrayOfData[i] - (double) average;
                arrayOfDeviation[i] = Math.Abs((decimal) Math.Pow(firstDeviation, 2));
            }
            
            foreach (decimal value in arrayOfDeviation)
            {
                total += value;
            }

            return total / arrayOfDeviation.Length;
        }

        private static void PrintEnumValues(IEnumerable<decimal> enumerable)
        {
            
            foreach (decimal value in enumerable)
            {
                Console.Write($"{value}, ");
                Console.WriteLine();
            }
        }
    }
}