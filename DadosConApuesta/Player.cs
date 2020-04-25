using System;
using System.Text;
using DadosConApuesta;

namespace DadosConApuesta
{
    public class Player
    {
        private decimal balance = 100;
        private string name = "";

        public Player(string name)
        {
            this.name = name;
        }

        public bool addBalance(decimal amount)
        {
            if (amount > 0)
            {

                this.balance += amount;
                return true;
            }

            return false;
        }

        public bool substractBalance(decimal amount)
        {

            if (amount > 0 && this.balance >= amount)
            {

                this.balance -= amount;
                return true;
            }

            return false;
        }
        
        public decimal getBalance()
        {

            return balance;
        }

        public string getName()
        {

            return name;
        }

        public bool isSamePlayer(Player p)
        {

            if (this.Equals(p))
            {

                return true;
            }

            return false;
        }

        protected bool Equals(Player other)
        {
            return balance == other.balance && name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(balance, name);
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder("Player's name: ");
           sb.Append(this.name).Append("\n");
           sb.Append("Player's balance: ").Append(this.balance).Append("\n");

           return sb.ToString();
        }
    }
}