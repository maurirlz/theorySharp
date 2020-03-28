using System;
using System.Collections.Generic;
using System.Linq;

namespace theorySharp
{
    class Clase2
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to convert it to a substring: ");
            String s1 = Console.ReadLine();
            
            Console.WriteLine("Please provide a value: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please provide a 2nd value: ");
            int num2 = Convert.ToInt32(Console.ReadLine());


            var doubleSum = num1 + num2;
            var doubleSub = num1 - num2;
            var doubleMul = num1 * num2;
            var doubleDiv = (double) num1 / num2;

            Console.WriteLine($"Sum result: {doubleSum}.");
            Console.WriteLine($"Subtraction result: {doubleSub}.");
            Console.WriteLine($"Multiplication result: {doubleMul}");
            Console.WriteLine($"Division result: {doubleDiv}");
            
            Console.WriteLine(ToSubString(s1) + " is the result of toSubString method");

            List<int> nums = new List<int>
            {
                num1,
                num2,
                50,
                700,
                900,
                1000
            };
            
            // linq test

            var list =
                from num in nums
                where num > 500
                select num;

            foreach (int num in list)
            {

                Console.WriteLine(num);
            }
        }

        /*
         * Test mio hecho durante clase virtual
         */

        private static String ToSubString(String s1)
        {

            if (s1.Length > 5)
            {
                return s1.Substring(2, 5);
            } else
            {
                return "Can't create a substring from String inputted.";
            }
        }
    }
}
