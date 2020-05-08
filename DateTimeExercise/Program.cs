using System;
using System.Text;

namespace DateTimeExercise
{
    class Program
    {
            /*
            Elabore una aplicación de consola que dadas una fecha de inicio y una fecha de fin, liste todas las
            fechas cuya posición en el año sea un número primo y además que correspondan a un día entre lunes y
            viernes.
            Ingrese dichas fechas en orden creciente (cronológicamente) con el formato:
            diaño:ddMMaa,diaño:ddMMaa,...,diaño:ddMMaa,
            Por ejemplo: Entre las fechas 01/01/2019 y 15/02/2019, el resultado esperado es
            2:020119,3:030119,7:070119,11:110119,17:170119,23:230119,29:290119,31:310119,37:060219,43:120
            219,
            Note, por ejemplo, que el 5to dia del año si bien es primo, no se encuentra listado porque cae sábado.
            Como ayuda recuerde que los primeros 10 números primos son: 2 3 5 7 11 13 17 19 23 29 
            */
            
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2018, 10, 01);
            DateTime dt2 = new DateTime(2019, 09, 10); // son 47 fechas

            String result = PrintAllPrimePositionedAndWorkingDays(dt, dt2);

            Console.WriteLine(result);
            Console.WriteLine();
        }

        private static string PrintAllPrimePositionedAndWorkingDays(DateTime firstDate, DateTime secondDate)
        {
            StringBuilder sb = new StringBuilder();

            while (firstDate <= secondDate)
            {

                if (IsPrime(firstDate.DayOfYear) && !IsWeekendDay(firstDate))
                {

                    sb.Append(firstDate.DayOfYear + ":" + firstDate.ToString("ddMMyy") + "\n");
                }
                
                firstDate = firstDate.AddDays(1);
            }
            
            return sb.ToString();
        }
        
        private static bool IsWeekendDay(DateTime dt)
        {

            return dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;
        }

        private static bool IsPrime(int num)
        {

            if (num <= 1) return false; // 1 o numeros negativos no son primos.
            if (num == 2) return true; // 2 no es primo.
            if (num % 2 == 0) return false; // si es par, no es primo, todos los pares son compuestos.

            var boundary = (int) Math.Floor(Math.Sqrt(num)); // Sacamos la raiz cuadrada del numero en cuestion para dar un limite a for

            for (int i = 3; i <= boundary; i += 2) // desde i = 3 (ya descartamos 1 y 2), i <= limite establecido, i += 2 para ir recorriendo entre numeros inpares (los unicos q pueden o no ser primos)
            {

                if (num % i == 0) // si el numero es divisible por el numero inpar, en este caso 3, retornar falso, ya que solo puede ser divisible por si mismo.
                {

                    return false;
                }
            }

            return true;
        }
    }
}
