using System;
using System.Text;

namespace theorySharp.Clase3
{
    public class Clase3
    {
        public static void Main(string[] args)
        {

            /* Objetivo: Comprender la aplicación de las estructuras de decisión en C#.
                * Ejercicio:
                    * Cree de una aplicación de consola.
                    * Solicite el ingreso de un texto y controle que no esté vacío.
                    * Despliegue un menú que muestre 3 posibilidades (Texto en mayúscula, Texto en minúscula y Texto Original).
                    * Capture la entrada con Console.Readkey y realice la opción solicitada. 
                    */

            bool flag = false;
            
            Console.WriteLine("Please input a string: ");
            string s = Console.ReadLine();
            s = CheckForEmptyString(s);

            StringBuilder sb = new StringBuilder();
            sb = BuildMenu(sb);

            do
            {
                Console.WriteLine(sb.ToString());
                ConsoleKeyInfo input = Console.ReadKey();

                if (input.Key.Equals(ConsoleKey.D4))
                {

                    flag = true;
                }
                else
                {
                    Console.WriteLine(DisplayString(input, s));
                }

            } while (!flag);
        }

        private static String CheckForEmptyString(string s)
        {
            var flag = false;

            do
            {
                if (s.Length > 0)
                {
                    flag = true;
                }
                else
                {

                    Console.WriteLine("String was empty, please input a new string: ");
                    s = Console.ReadLine();
                }
            } while (!flag);

            return s;
        }

        private static StringBuilder BuildMenu(StringBuilder sb)
        {

            sb.Append("------------------- MENU -------------------\n");
            sb.Append("Input 1 in order to show the inputted text in upper case.\n");
            sb.Append("Input 2 in order to show the inputted text in lower case.\n");
            sb.Append("Input 3 in order to show the text in it's original format.\n");
            sb.Append("Input 4 to exit. \n");

            return sb;
        }

        private static string DisplayString(ConsoleKeyInfo input, string s)
        {

            switch (input.Key)
            {
                case ConsoleKey.D1:

                    return s.ToUpper();

                case ConsoleKey.D2:

                    return s.ToLower();

                case ConsoleKey.D3:

                    return s;
                default:

                    return "Key not accepted as a menu option.";
            }
        }
    }
}