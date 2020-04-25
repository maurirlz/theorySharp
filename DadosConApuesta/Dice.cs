using System;

namespace DadosConApuesta
{
    public class Dice
    {
        private static int faces;

        public Dado(int faces)
        {
            this.faces = faces;
        }

        public int throwDice()
        {
            
            return new Random().Next(numbers) + 1;
        }
    }
}