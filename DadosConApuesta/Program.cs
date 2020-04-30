using System;
using Microsoft.VisualBasic.CompilerServices;
using static System.Console;

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

            
            Game game = new Game(player, secondPlayer, 6);
            NewBet(game, player);
        }

        private static void NewBet(Game g, Player p)
        {
            WriteLine($"Hey {p.Name} please input your desired amount to bet on: ");
            decimal amount = Decimal.Parse(ReadLine());
            WriteLine($"{p.Name}, please enter the desired number to bet on (from 1 to {g.GetDiceFaces})");
            int choice = Int32.Parse(ReadLine());
            WriteLine($"{p.Name}, please enter the desired gamemode: (-1/2 Conservative, -2/5 Risky, -4/15 Desperate");
            string mode = ReadLine();

            Gamble newGamble = g.InitializeBet(mode, amount, p, choice);

            if (newGamble != null)
            {
                WriteLine("Bet sucessfully added.");
                GetGambleInfo(newGamble);
            }
            else
            {
                
                WriteLine("Couldn't process new bet, something bad happened.");
            }
        }

        public static bool GameIsOverCheck(Game g)
        {
            return g.IsGameFinished();
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

            WriteLine(gamble.GetGambleInfo());
        }
    }
}