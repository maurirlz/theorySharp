using System;
using static System.Console;

namespace Ejercicio7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DateTime fecha = new DateTime(2020, 5 , 10);
            DateTime fecha1 = new DateTime(2020, 5, 20);

            WriteLine($"Dias entre {fecha.Date} y {fecha1.Date}: {Math.Abs(GetDaysBetweenTwoDates(fecha, fecha1))}");
            WriteLine($"Dias laborales entre {fecha.Date} y {fecha1.Date}: {GetWorkingDays(fecha, fecha1)}");
            WriteLine($"{fecha.Date} mas 5 dias laborales: {AddWorkingDays(fecha, 6)}");
        }

        private static int GetDaysBetweenTwoDates(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = dt1 - dt2;

            
            return ts.Days;
        }

        private static int GetWorkingDays(DateTime firstDate, DateTime lastDate, params DateTime[] holidayBank)
        {
            /* Sacamos las fechas de cada datetime pasado. */

            firstDate = firstDate.Date;
            lastDate = lastDate.Date;

            /* Si la primera fecha pasada es mayor a la segunda fecha, tirar una excepcion, ya que no tiene logica. */
            
            if (firstDate > lastDate)
            {
                throw new ArgumentException("Last date greater than first date.");
            }

            TimeSpan total = GetTimeSpanBetweenTwoDates(firstDate, lastDate);
            
            /* Sacamos el total de dias entre las 2 fechas y sumamos 1 para contar el dia por el cual empezamos. */
            
            int businessDays = total.Days + 1;
            
            /* Sacamos el total de semanas diviendo el total de dias por siete. (total de dias en una semana) */
            
            int totalWeeks = businessDays / 7; 
            
            /* Condicional para filtrar los fin de semana del total de businessDays, que cuenta tanto dias laborales como no laborales:  */

            if (businessDays > totalWeeks * 7)
            {

                /* Sacamos el dia que es de los parametros que son pasados a la funcion, si es domingo, para contemplar la logica usada en el programa,
                 * contemplamos que domingo sea igual a 7 en vez de su valor real (DayofWeek.Sunday == 0)
                 */

                int firstDayOfWeek = GetDayOfWeek(firstDate);
                int lastDayOfWeek = GetDayOfWeek(lastDate);
                
                /* Determinamos si hay algun fin de semana que puede ser de 1 dia (es domingo) o 2 dias (es sabado). */

                /* firstDayOfWeek = 3 (Miercoles), lastDayOfWeek = 2 (Martes) empezamos a contar desde la proxima semana (lastDayOfWeek += 7) */
                
                if (lastDayOfWeek < firstDayOfWeek)
                {
                    lastDayOfWeek += 7;
                }
                
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7) // Sabado y domingo estan en lo que queda del intervalo.
                    {
                        businessDays -= 2;
                    } else if (lastDayOfWeek >= 6) // solo sabado queda en el intervalo.
                    {
                        businessDays -= 1;
                    } 
                } else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7) // Solo queda un domingo en el intervalo
                {
                    businessDays -= 1;
                }
            }
            businessDays -= totalWeeks + totalWeeks;
            
            /* Restamos todos los dias feraidos recibidos como params. asegurandonos que no restamos el mismo dia 2 veces con IsWeekendDay: */
            
            foreach (var holiday in holidayBank)
            {

                DateTime holidayDate = holiday.Date;

                if (firstDate <= holidayDate && holidayDate <= lastDate && !(IsWeekendDay(holidayDate)))
                {
                    --businessDays;
                }
            }

            return businessDays;
        }

        private static DateTime AddWorkingDays(DateTime date, int workingDays)
        {

            while (workingDays > 0)
            {

                date = date.AddDays(1);

                if (!IsWeekendDay(date))
                {
                    workingDays -= 1;
                }
            }

            return date;
        }

        private static bool IsWeekendDay(DateTime dt)
        {

            return dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Saturday;
        }

        private static TimeSpan GetTimeSpanBetweenTwoDates(DateTime dt1, DateTime dt2)
        {

            return dt2 - dt1;
        }

        private static int GetDayOfWeek(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Sunday ? 7 : (int) dateTime.DayOfWeek;
        }
    }
}