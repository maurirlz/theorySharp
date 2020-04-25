namespace DadosConApuesta
{
    public class Gamble
    {
        private int result;
        private Dice _dice;
        private Player player;
        private decimal amount;
        private GameMode gameMode;

        public Gamble(decimal amount, Player player)
        {
            this.amount = amount;
            this.player = player;
        }

        private int getResult()
        {
            
        }

    }
}