using System;
using System.Text;

namespace DadosConApuesta
{
    public class Gamble
    {
        private static long _gambleId;
        private decimal _initialAmount;
        private decimal _totalamountToLose;
        private decimal _totalamountToWin;
        private GameMode _gameMode;
        private readonly Player _player;

        public Gamble(Player player)
        {
            _player = player;
        }

        public bool MakeBet(Player player, GameMode mode, decimal amount)
        {
            if (player.HasEnoughCurrencyToPlay() && amount > 0)
            {
                switch (mode)
                {
                    case GameMode.Conservative:

                        _gameMode = GameMode.Conservative;
                        _initialAmount = amount;
                        _totalamountToWin = amount * 2;
                        _totalamountToLose = -amount;
                        
                        break;
                    case GameMode.Risky:
                        
                        _gameMode = GameMode.Risky;
                        _initialAmount = amount;
                        _totalamountToWin = amount * 5;
                        _totalamountToLose = -amount * 2;
                        
                        break;
                    case GameMode.Desperate:
                        
                        _gameMode = GameMode.Desperate;
                        _initialAmount = amount;
                        _totalamountToWin = amount * 15;
                        _totalamountToLose = -amount * -4;
                        
                        break;
                }
            }
            else
            {
                
                ThrowInvalidAmuntOfBalanceException(player);
            }

            _gambleId++;
            return true;
        }

        private static void ThrowInvalidAmuntOfBalanceException(Player player)
        {
            Console.WriteLine($"Player {player.Name} doesn't meet the required balance to play the game. \n\tException at Gamble Class.");
            throw new InvalidAmountOfBalanceException("Balance quantity is 0 or less.");
        }

        public string GetGambleInfo()
        {

            return ToString();
        }

        private static long GetGambleId => _gambleId;

        public decimal GetAmountToLose => _totalamountToLose;

        public decimal GetAmountToWin => _totalamountToWin;
        
        private string GetGameMode(GameMode gameMode)
        {

            if (gameMode == GameMode.Conservative)
            {

                return "Conservative";
            }  
            
            return gameMode == GameMode.Risky ? "Risky" : "Desperate";
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\n Gamble ID: {GetGambleId}")
                .Append($"\n\tPlayer associated with bet: {_player}")
                .Append($"\n\t\tAmount betted: {_initialAmount}")
                .Append($"\n\t\tAmount to win: {GetAmountToWin}")
                .Append($"\n\t\tAmount to lose: {GetAmountToLose}")
                .Append($"\n\tbetted on {GetGameMode(_gameMode)} mode.");

            return sb.ToString();
        }
    }
}