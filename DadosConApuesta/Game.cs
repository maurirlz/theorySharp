using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace DadosConApuesta
{
    public class Game
    {
        private readonly List<Player> _players;
        private readonly List<Dice> _dices;
        private readonly List<Gamble> _bets;
        private readonly Dictionary<Dice, int> _results;
        private readonly Dictionary<Player, int> _choices;
        private static decimal _jackpot = 10000;
        private static int _dicerules;

        public Game(Player p1, Player p2, int dicesFaces)
        {
            if (!p1.IsSamePlayer(p2))
            {

                _players = new List<Player>();
                _players.Add(p1);
                _players.Add(p2);
            }
            else
            {
                throw new InvalidDataException("Players are the same, cannot start the game.");
            }

            _dices = new List<Dice>();
            Dice player1Dice = new Dice(dicesFaces);
            Dice player2Dice = new Dice(dicesFaces);

            _dicerules = dicesFaces;
            _dices.Add(player1Dice);
            _dices.Add(player2Dice);

            _results = new Dictionary<Dice, int>();
            _bets = new List<Gamble>();
            _choices = new Dictionary<Player, int>();
        }

        public void StartARound()
        {
            ThrowDices();
        }

        public void DecideWinners(List<Player> players)
        {
            foreach (var result in _results.Values)
            {
                foreach (var player in players)
                {
                    if (_choices[player] == result)
                    {
                        player.IsWinner = true;
                    }
                }
            }
        }

        public void PayWinnersAndChargeLosers()
        {
            _players.ForEach(player =>
            {
                Gamble playersBet = _bets.Find(betPlayer => player.Equals(betPlayer));

                if (player.IsWinner)
                {
                    player.AddBalance(playersBet.GetAmountToWin);
                }
                else
                {
                    player.SubtractBalance(playersBet.GetAmountToLose);
                }
            });
        }

        public Gamble InitializeBet(String mode, decimal amount, Player p, int choice)
        {
            Player foundPlayer = _players.Find(desiredPlayer => p.Equals(desiredPlayer));

            if (foundPlayer != null)
            {
                Gamble gamble = new Gamble(p);
                gamble.MakeBet(p, gamble.GetGameMode(mode), amount);
                _choices.Add(p, choice);
                return gamble;
            }

            return null;
        }

        public bool IsGameFinished()
        {
            if (_jackpot <= 0)
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

        private void ThrowDices()
        {
            foreach (Dice dice in _dices)
            {
                
                _results.Add(dice, dice.throwDice());
            }
        }

        private decimal GetJackpot() => _jackpot;
        
        public List<Player> GetListOfPlayers => new List<Player>(_players);
        
        public List<Gamble> GetListOfBets => new List<Gamble>(_bets);
        
        public Dictionary<Player, int> GetListOfChoices => new Dictionary<Player, int>(_choices);

        public int GetDiceFaces => _dicerules;
    }
}