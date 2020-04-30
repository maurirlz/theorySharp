using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace DadosConApuesta
{
    public class Game
    {
        private readonly HashSet<Player> _players;
        private readonly HashSet<Dice> _dices;
        private readonly List<Gamble> _bets;
        private readonly Dictionary<Dice, int> _results;
        private static decimal _jackpot = 10000;

        public Game(Player p1, Player p2, int dicesFaces)
        {
            if (!p1.IsSamePlayer(p2))
            {

                _players.Add(p1);
                _players.Add(p2);
            }
            else
            {
                throw new InvalidDataException("Players are the same, cannot start the game.");
            }

            _dices = new HashSet<Dice>();
            Dice player1Dice = new Dice(dicesFaces);
            Dice player2Dice = new Dice(dicesFaces);

            _dices.Add(player1Dice);
            _dices.Add(player2Dice);

            _results = new Dictionary<Dice, int>();
            _bets = new List<Gamble>();
        }

        public void StartGame()
        {
            ThrowDices();
        }

        public bool IsGameFinished()
        {
            if (GetJackpot() <= 0)
            {
                Console.WriteLine("Jackpot's value is 0, game is finished.");
                return true;
            } 
            
            foreach (Player player in _players)
            {
                if (!player.HasEnoughCurrencyToPlay())
                {
                    Console.WriteLine($"Player ${player.Name} lost due to having a balance of zero or negative.");
                    return true;
                }
            }
            
            return false;
        }
        
        public bool InitializeBets(String mode, decimal amount)
        {
            foreach (Player player in _players)
            {
                Gamble gamble = new Gamble(player);
                gamble.MakeBet(player, gamble.GetGameMode(mode), amount);
                _bets.Add(gamble);
            }

            return true;
        }

        private void ThrowDices()
        {
            foreach (Dice dice in _dices)
            {
                
                _results.Add(dice, dice.throwDice());
            }
        }

        private decimal GetJackpot() => _jackpot;
        
        public HashSet<Player> GetListOfPlayers => new HashSet<Player>(_players);
        
        public List<Gamble> GetListOfBets => new List<Gamble>(_bets);
    }
}