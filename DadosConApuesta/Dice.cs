using System;

namespace DadosConApuesta
{
    public class Dice
    {
        private int faces { get; }
        private int result { get; set; }

        public Dice(int faces)
        {
            this.faces = faces;
        }

        public int throwDice()
        {
            this.result = new Random().Next(this.faces);
            return result;
        }
    }
}