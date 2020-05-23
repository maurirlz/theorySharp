using System;

namespace Interfaces
{
    public class Program
    {
        static void Main(string[] args)
        {

            Libro[] biblioteca = PedirBiblioteca();
            biblioteca = PedirLibros(biblioteca);
            
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("\t\t\tLIBROS DESORDENADOS: ");
            Console.WriteLine("--------------------------------------------------------------------");
            MostrarLibrosDesordenados(biblioteca);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("\t\t\tLIBROS ORDENADOS: ");
            Console.WriteLine("--------------------------------------------------------------------");
            MostrarLibrosOrdenados(biblioteca);
        }

        private static Libro[] PedirLibros(Libro[] biblioteca)
        {
            
            int cantidad;
            string autor;
            string titulo;
            
            Console.WriteLine("Ingrese la cantidad de libros que seran agregados a la biblioteca: ");
            cantidad = Int32.Parse(Console.ReadLine() ?? "3");

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Ingrese el autor del libro {i + 1}: ");
                autor = Console.ReadLine();

                Console.WriteLine($"Ingrese el titulo del libro {i + 1}: ");
                titulo = Console.ReadLine();
                
                biblioteca[i] = new Libro(autor, titulo);
            }

            return biblioteca;
        }

        private static Libro[] PedirBiblioteca()
        {

            Console.WriteLine("Ingrese el tamaño de la bibliotica: ");
            Libro[] biblioteca = new Libro[Int32.Parse(Console.ReadLine() ?? "3")];

            return biblioteca;
        }

        private static void MostrarLibrosDesordenados(Libro[] biblioteca)
        {
            foreach (Libro libro in biblioteca)
            {

                Console.WriteLine(libro.Describir());
            }
        }

        private static void MostrarLibrosOrdenados(Libro[] biblioteca)
        {
            Array.Sort(biblioteca);
            
            foreach (Libro libro in biblioteca)
            {
                
                Console.WriteLine(libro.Describir());
            }
        }
    }
}