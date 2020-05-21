using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CesarCypherExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Utilizando el tipo string y/o char elabore un programa de consola que descifre un texto cifrado según el algoritmo César.
            Consideraciones:

                Se tomará el texto cifrado por consola
                Se tomará la clave de cifrado por consola
                Los únicos caracteres que se podrán cifrar son los siguientes aábcdeéfghiíjklmnñoópqrstuúüvwxyz
                Todos los demás aparecerán sin cifrar
‌
                Como prueba el texto que deben descifrar es
                fcyb ry pbabpüzüragb ehr yyruñ qrfqr qragéb rf ry jréqñqréb pbabpüzüragb
           ‌ */

            string menu = BuildMenu();

            while (true)
            {
                Console.WriteLine(menu);
                ConsoleKeyInfo input = Console.ReadKey();

                if (input.Key.Equals(ConsoleKey.D3))
                {

                    break;
                }

                Console.WriteLine("Enter the desired text to cypher: ");
                string desiredText = Console.ReadLine()?.ToLower();
                Console.WriteLine("Input the desired amount of shift that this text has / you want to have on the text.");
                int key = Int32.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine(MenuActions(input, desiredText, key));
            }
        }

        private static string EncryptPhrase(string[] phrase, String alphabet, int key)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string word in phrase)
            {
                sb.Append(EncryptText(word.Trim(), alphabet, key));
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd();
        }

        private static string DecryptPhrase(string[] phrase, String alphabet, int key)
        {
            
            StringBuilder sb = new StringBuilder();

            foreach (string word in phrase)
            {

                sb.Append(DecryptText(word.Trim(), alphabet, key));
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd();
        }

        private static string EncryptText(string s, string alphabet, int key)
        {

            char[] alphabetArray = alphabet.ToCharArray();
            key %= alphabet.Length; // aseguramos que el shift este entre los valores del vocabulario
            StringBuilder sb = new StringBuilder();

            foreach (char character in s)
            {
                
                int shiftedCharNumber = ShiftCharNumber(character, alphabet, key);
                sb.Append(alphabetArray[shiftedCharNumber]);
            }

            return sb.ToString();
        }

        private static string DecryptText(string s, string alphabet, int key)
        {

            char[] alphabetArray = alphabet.ToCharArray();
            key %= alphabet.Length;
            StringBuilder sb = new StringBuilder();

            foreach (var character in s)
            {
                int unshiftedCharNumber = UnshiftCharNumber(character, alphabet, key);
                
                
                sb.Append(alphabetArray[unshiftedCharNumber % alphabet.Length]);
            }

            return sb.ToString();
        }

        private static int ShiftCharNumber(char character, string alphabet, int key)
        {

            int unshiftedNum = alphabet.IndexOf(character);

            return (unshiftedNum + key) % alphabet.Length;
        }

        private static int UnshiftCharNumber(char character, string alphabet, int key)
        {

            int shiftedNum = alphabet.IndexOf(character);

            int unshiftedNumber = (shiftedNum - key) % alphabet.Length;

            if (unshiftedNumber < 0)
            {
                unshiftedNumber += alphabet.Length;
            } 

            return unshiftedNumber;
        }

        private static bool ContainsProhibitedChar(string stringToTest)
        {
            
            // Expresiones regulares: son patrones representados en string que pueden representar a su vez, distintos patrones de String, en este caso
            // al darle el patron [^aábcdeéfghiíjklmnñoópqrstuúüvwxyz] los corchetes representan un intervalo entre caracterez ( a a la z seria [a-z])
            // por lo cual al definir un rango de a-z con vocales con acento inclusive, definimos una expresion regular que representa nuestra whitelist de caracteres.
            // el ^ al comienzo de la expresion regular representa negacion, esto es, niega toda la expresion regular para encontrar caracteres QUE NO SON de nuestra whitelist.
            // devolvemos el resultado de dicha comparacion con isMatch, si es true, significa que hay un caracter prohibido, si es false, toda la string que comapramos es valida.
            
            Regex regularExpression = new Regex("[^aábcdeéfghiíjklmnñoópqrstuúüvwxyz]");

            return regularExpression.IsMatch(stringToTest);
        }

        private static string BuildMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Cesar's Cypher menu: ")
                .Append("\nSelect your desired action: ")
                .Append("\n\t1.Encipher a phrase with a desired key as shifter. (Must be a number.)")
                .Append("\n\t2.Decipher a phrase with the requested key.")
                .Append("\n\t3.QUIT");

            return sb.ToString();
        }

        private static string MenuActions(ConsoleKeyInfo input, string s, int key)
        {
            String alphabet = "aábcdeéfghiíjklmnñoópqrstuúüvwxyz";
            
            switch (input.Key)
            {
                case ConsoleKey.D1:

                    return EncryptPhrase(s.Split(" "), alphabet, key);
                case ConsoleKey.D2:

                    return DecryptPhrase(s.Split(" "), alphabet, key);
                default:

                    return "Wrong input, please select one of both options.";
            }
        }
    }
}