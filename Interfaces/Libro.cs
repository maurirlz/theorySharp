using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Interfaces
{
    public class Libro : IColeccionable, IComparable
    {
        private string _author;
        private string _titulo;

        // Propiedades.
        public string Titulo() => _titulo;

        public string Author
        {
            get => _author;
            set
            {
                Regex regex = new Regex("[a-zA-Z.]");
                
                if (regex.IsMatch(value))
                {
                    _author = value;
                }
            }
        }

        public Libro(string author, string titulo)
        {
            _author = author;
            _titulo = titulo;
        }

        public string Describir()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Un libro del autor: ").Append(_author)
                .Append("\n Su titulo es: ").Append(_titulo);

            return sb.ToString();
        }
        
        // ordenar por titulo
        
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Libro otroLibro = obj as Libro;

            if (otroLibro != null)
            {
                return String.Compare(Titulo(), otroLibro.Titulo(), StringComparison.OrdinalIgnoreCase);
            }

            throw new ArgumentException("Objeto dado no es un libro.");
        }
        
        private bool Equals(Libro other)
        {
            return _author == other._author && _titulo == other._titulo;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Libro) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_author, _titulo);
        }
    }
}