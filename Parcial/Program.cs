using System;
using System.Collections.Generic;

namespace Parcial
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt1 = new DateTime(2011, 08, 16);
            DateTime dt2 = new DateTime(2011, 08, 18);
            
            PeriodoDeTiempo p = new PeriodoDeTiempo(dt1, dt2, dt2 - dt1);
            
            DateTime dt3 = new DateTime(2012, 08, 27);
            DateTime dt4 = new DateTime(2012, 08, 29);
            
            PeriodoDeTiempo p1 = new PeriodoDeTiempo(dt3, dt4, dt4 - dt3);

            PeriodoDeTiempo[] periodos = {p, p1};
            
            UnionDeTiempo unionDeTiempo = new UnionDeTiempo(periodos);
            
            int i = 0;
            
            foreach (var periodoDeTiempo in unionDeTiempo.GetNonIntersectedUnion())
            {
                
                Console.WriteLine("Periodos que no se interseccionan: ");
                Console.WriteLine($"\tPeriodo : {i + 1} "  +
                                  "\n\t\t" + periodoDeTiempo.Inicio +
                                  " a " + periodoDeTiempo.Fin);

                i++;
            }
        }
    }
    
    class PeriodoDeTiempo
    {
        private DateTime _inicio;
        private DateTime _fin;
        private TimeSpan _duracion;

        public bool interceptaOtroPeriodoDeTiempo { get; set; }
        public void SetInicio(DateTime dt) => _inicio = dt;

        public void SetFin(DateTime dt) => _fin = dt;
        
        public void SetDuracion(TimeSpan timeSpan) => _duracion = timeSpan;
        
        public PeriodoDeTiempo(DateTime inicio, DateTime fin, TimeSpan duracion)
        {
            _inicio = inicio;
            _fin = fin;
            _duracion = duracion;
        }

        public DateTime Inicio => _inicio;

        public DateTime Fin => _fin;
        public TimeSpan Duracion => _duracion;
        
        // Sobreescribimos equals y hashcode() para poder comparar entre periodos de tiempo y ver si son iguales.
        // (equals por defecto solo compara la referencia de un objeto con la de otro, pero esto no significa que
        // sean iguales, sobreescribir equals y hashcode nos asegura que 2 periodos de tiempo solo son iguales 
        // si tienen los valores de sus fields/campos, y son de la misma istancia.

        protected bool Equals(PeriodoDeTiempo other)
        {
            return _inicio.Equals(other._inicio) 
                   && _fin.Equals(other._fin) 
                   && _duracion.Equals(other._duracion) 
                   && interceptaOtroPeriodoDeTiempo == other.interceptaOtroPeriodoDeTiempo;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PeriodoDeTiempo) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_inicio, _fin, _duracion, interceptaOtroPeriodoDeTiempo);
        }
    }
    
    class UnionDeTiempo
    {
        private PeriodoDeTiempo[] periodosDeTiempo;

        public UnionDeTiempo(PeriodoDeTiempo[] periodosDeTiempo)
        {
            this.periodosDeTiempo = periodosDeTiempo;
        }

        public PeriodoDeTiempo[] GetNonIntersectedUnion()
        {
<<<<<<< HEAD
            PeriodoDeTiempo[] arrayDeTiemposQueNoInterceptan = new PeriodoDeTiempo[10];
=======
           PeriodoDeTiempo[] arrayDeTiemposQueNoInterceptan = new PeriodoDeTiempo[10];
>>>>>>> d84332bca0a0babae21e8a2b2e58b0ce13ba4eb0
            
            InterceptaOtroPeriodoDeTiempoCheck();

            for (var i = 0; i < periodosDeTiempo.Length; i++)
            {
                if (!periodosDeTiempo[i].interceptaOtroPeriodoDeTiempo)
                {
                    arrayDeTiemposQueNoInterceptan[i] = periodosDeTiempo[i];
                }
            }

            return arrayDeTiemposQueNoInterceptan;
        }

        /*Explicacion: la union de 2 periodos de tiempo es conseguir el la fecha de inicio mas chica y la mecha de fin mas grande entre un conjunto de periodos.
        ej: periodo 1: 26/05/2020 a 28/05/2020
        periodo 2: 27/05/2020 a 29/05/2020
        la union de esos peridoso seria una fechas que contenga a ambos, en este caso, 26/05/2020 a 29/05/2020.
        
        creamos un nuevo periodo de tiempo, con inicio como el valor maximo y fin como valor minimo de datetime (explicacion de esto mas adelante.)
        recorremos el arreglo y chequeamos siempre si hay una interseccion entre las fechas que estamos comparando llamando al metodo de check,
        si no hay interseccion, es un periodo de tiempo completo por si mismo, el cual no nos interesa sacar porque no sera parte de la union.
        Aca, se explica la parte de porque pusimos a inicio como valor maximo de una fecha y fin como valor minimo de una fecha:
        Como sabemos que inicio siempre va a ser el MENOR valor de los inicios de todas las fechas en el array, necesitamos comparar el primer item
        de dicha lista con algo, ya q si no seteamos este valor, no se podra realizar la primera comparacion, asique si o si necesitamos un valor 
        ademas de esto, el array fuera de nuestro conocimiento, puede tener cualquier periodo de tiempo desde 01/01/0001 hasta la fecha maxima, 
        por lo cual si empezamos la comparacion con el valor MAXIMO posible para inicio, sabemos que todo lo que haya en el array sera menor que el valor maximo
        , asegurandonos asi, que podemos comaprar correctamente todos los elementos del array.
        
        Ej: si queremos chequear el elemento minimo de un array de enteros, [1,-50,2,3,4,5], nuestro comaprador agarrar el valor maximo de enteros (2^32) y sera comparado
        con el 1, si esto es verdadero (lo cual es), asignamos a 1 como nuestro nuevo comparador, y asi con todo el array.
        La logica del comparador con fin es la misma pero al revez, necesitamos el valor mas chico para iniciarlo como comparador, asegurandonos de que todos los elementos de array 
        sean mas chicos q este.
        
        Una vez recorrimos el array entero ya sacando los valores inicio y fin minimos y maximos, conseguimos la duracion de este periodo y lo devolvemos como un periodo de tiempo.
        Para los periodos que no tienen una interseccion con otro dentro del array esta el otro metodo, el cual solo devuelve un array de estos periodos, haciendo un check de si se 
        interseccionan o no. Completando asi, el punto que pide el profesor (dar la union de los que se intersectan y los periodos que no se intersectan.)
        */
        public PeriodoDeTiempo GetUnion()
        {
            
            PeriodoDeTiempo unionDePeriodosDeTiempo = new PeriodoDeTiempo(DateTime.MaxValue,  DateTime.MinValue, DateTime.MaxValue - DateTime.MinValue);

            InterceptaOtroPeriodoDeTiempoCheck();
            
            foreach (PeriodoDeTiempo periodoDeTiempo in periodosDeTiempo)
            {
                if (periodoDeTiempo.interceptaOtroPeriodoDeTiempo)
                {
                    if (periodoDeTiempo.Inicio < unionDePeriodosDeTiempo.Inicio)
                    {
                        unionDePeriodosDeTiempo.SetInicio(periodoDeTiempo.Inicio);
                    }

                    if (periodoDeTiempo.Fin > unionDePeriodosDeTiempo.Fin)
                    {

                        unionDePeriodosDeTiempo.SetFin(periodoDeTiempo.Fin);
                    }
                }
            }

            unionDePeriodosDeTiempo.SetDuracion(unionDePeriodosDeTiempo.Fin - unionDePeriodosDeTiempo.Inicio);

            return unionDePeriodosDeTiempo;
        }

        public TimeSpan CalcularSumatoriaTiempos()
        {
            TimeSpan acum = new TimeSpan();
            
            for (var i = 0; i < periodosDeTiempo.Length; i++)
            {
                acum += periodosDeTiempo[i].Duracion;
            }

            return acum;
        }

        public void InterceptaOtroPeriodoDeTiempoCheck()
        {
            PeriodoDeTiempo aux = periodosDeTiempo[0];
            
            foreach (PeriodoDeTiempo periodoDeTiempo in periodosDeTiempo)
            {
                if (periodoDeTiempo.Equals(aux))
                {

                    continue;
                }

                if (periodoDeTiempo.Inicio < aux.Inicio || periodoDeTiempo.Fin > aux.Fin)
                {
                    periodoDeTiempo.interceptaOtroPeriodoDeTiempo = false;
                }
                else
                {
                    periodoDeTiempo.interceptaOtroPeriodoDeTiempo = true;
                }

                aux = periodoDeTiempo;
            }
        } 
    }
}
