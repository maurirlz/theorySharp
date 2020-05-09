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
            unionDeTiempo.InterceptaOtroPeriodoDeTiempoCheck();
            
            int i = 0;
            
            foreach (var periodoDeTiempo in unionDeTiempo.GetNonIntersectedUnion())
            {
                
                Console.WriteLine("Periodos que no se interseccionan: ");
                Console.WriteLine($"\tPeriodo : {i + 1} "  +
                                  "\n\t\t" + periodoDeTiempo.Inicio +
                                  " a " + periodoDeTiempo.Fin);

                i++;
            }
            
             // funciona, actually no me fue tan mal
        }
    }
    
    class PeriodoDeTiempo
    {
        private DateTime _inicio;
        private DateTime _fin;
        private TimeSpan _duracion;

        public bool interceptaOtroPeriodoDeTiempo { get; set; }
        
        public PeriodoDeTiempo(DateTime inicio, DateTime fin, TimeSpan duracion)
        {
            _inicio = inicio;
            _fin = fin;
            _duracion = duracion;
        }

        public DateTime Inicio => _inicio;

        public DateTime Fin => _fin;
        public TimeSpan Duracion => _duracion;

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

        public List<PeriodoDeTiempo> GetNonIntersectedUnion()
        {
            List<PeriodoDeTiempo> periodosDeTiempoQueNoInterceptan = new List<PeriodoDeTiempo>();
            
            for (var i = 0; i < periodosDeTiempo.Length; i++)
            {
                if (!periodosDeTiempo[i].interceptaOtroPeriodoDeTiempo)
                {
                    periodosDeTiempoQueNoInterceptan.Add(periodosDeTiempo[i]);
                }
            }

            return periodosDeTiempoQueNoInterceptan;
        }

        public DateTime GetUnion()
        {
            DateTime union;
            long ticksAcum = 0;
            
            for (var i = 0; i < periodosDeTiempo.Length; i++)
            {
                if (periodosDeTiempo[i].interceptaOtroPeriodoDeTiempo)
                {
                    ticksAcum += periodosDeTiempo[i].Inicio.Ticks + periodosDeTiempo[i].Fin.Ticks;
                }
            }
            
            union = new DateTime(ticksAcum);
            
            return union;
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
