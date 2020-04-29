using System;

namespace DadosConApuesta
{
    class Program
    {
        /*
         Ejemplo:
        Pozo empieza con 10000, el jugador 1 $100 y el jugador 2 $100
        Jugador 1 apuesta $10 (conservador) al nro 6
        Jugador 2 apuesta $20 (arriesgado) al nro 10
        Se corrobora que haya suficiente dinero en el pozo para pagar en el caso que gane la apuesta más elevada y que cada jugador pueda pagar lo apostado si pierde
        ‌
        Una posibilidad
        Se arrojan los dados y se obtiene 11
        Ambos pierden el jugador 1 se queda con $90, el jugador 2 se queda con $60
        El pozo acumula 10050
        ‌
        Otra posibilidad
        Se arrojan los dados y se obtiene 10
        El jugador 1 pierde, se queda con $90, el jugador 2 gana, se queda con $200 (100 + 5*20)
            El pozo acumula 10000 + 10 -100 = 9910
        */
        
        static void Main(string[] args)
        {
            Player player = new Player("Jugador 1");
            Player secondPlayer = new Player("Jugador 2");
            
            Gamble gamble = new Gamble(player);

            gamble.MakeBet(player, GameMode.Risky, 100);
            BalanceCheck(player);
            GetGambleInfo(gamble);
        }

        public static bool BalanceCheck(Player p1, Player p2)
        {

            return p1.HasEnoughCurrencyToPlay() && p2.HasEnoughCurrencyToPlay();
        }

        public static bool BalanceCheck(Player p1)
        {

            return p1.HasEnoughCurrencyToPlay();
        }

        private static void GetGambleInfo(Gamble gamble)
        {

            Console.WriteLine(gamble.GetGambleInfo());
        }
    }
}