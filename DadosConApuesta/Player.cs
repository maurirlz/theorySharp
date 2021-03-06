using System;
using System.Text;
using DadosConApuesta;

namespace DadosConApuesta {

    public class Player
    {
        private decimal _balance;
        private readonly string _name;
        public bool IsWinner { get; set; }

        public string Name => _name;

        public Player(string name)
        {
             _name = name;
             _balance = 100;
        }

        public void AddBalance(decimal amount)
        {
            if (amount > 0 && IsWinner)
            {

                 _balance += amount;
            }
        }

        public void SubtractBalance(decimal amount)
        {

            if (HasEnoughCurrencyToPlay() && _balance >= amount && !IsWinner)
            {

                _balance -= amount;
            }
        }

        public bool IsSamePlayer(Player p)
        {

            if (Equals(p))
            {

                return true;
            }

            return false;
        }

        public bool HasEnoughCurrencyToPlay() => _balance > 0;

        public decimal GetPlayerBalance => _balance;

        private bool Equals(Player other)
        {
            return _balance == other._balance && _name == other._name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_balance, _name);
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder("\n\tPlayer's name: ");
           sb.Append(_name).Append("\n");
           sb.Append("\tPlayer's balance: ").Append( _balance);

           return sb.ToString();
        }
    }
}