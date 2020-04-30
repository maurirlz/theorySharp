using System;

namespace DadosConApuesta
{
    public class Dice : IComparable<Dice>
    {

        private readonly int _faces;
        private int _result;
        
        public Dice(int faces)
        {
            _faces = faces;
        }

        public int throwDice()
        {
            _result = new Random().Next(_faces);
            return _result;
        }

        public int CompareTo(Dice other)
        {
            return _result < other._result ? -1
                :  _result > other._result ? 1
                : 0;
        }

        public int GetFaces => _faces;

        public int GetResult => _result;
    }
}