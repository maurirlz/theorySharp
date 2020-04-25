using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioClase
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Pasaje de parametros - Ejercicio
             * Implementar una funcion Moda, que reciba
             * como valores una cantidad indeterminada de enteros
             * y devuelva la Moda (estadistica), el valor minimo y el valor maximo
             * Invocar este metodo y mostrar los resultados por consola.
             * Elija los modificadores mas adecuados (in, out, ref, params)
             * 
             */
            
            int moda = getModa(out int a, out int b, 50, 49, 50, 65, 50, 49);
            Console.WriteLine($"Largest number in the array: {a}");
            Console.WriteLine($"Lowest number in the array: {b}");
            Console.WriteLine($"Most frequent number in the array: {moda}");
            
        }

        public static int getModa(out int max, out int min, params int[] integers)
        {
            
            max = Int32.MinValue;
            min = Int32.MaxValue;
            List<int> integersAsList = new List<int>(integers);

            int moda = (from num in integers
                group num by num
                into grp
                orderby grp.Count() descending
                select grp.Key).First();
            
            foreach (int integer in integers)
            {
                if (integer > max)
                {

                    max = integer;
                } else if (integer < min)
                {

                    min = integer;
                }
            }
            
            return moda;
        }
    }
}