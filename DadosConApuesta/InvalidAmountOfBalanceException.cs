using System;

namespace DadosConApuesta
{
    [Serializable()]
    
    public class InvalidAmountOfBalanceException : System.Exception
    {
        public InvalidAmountOfBalanceException() : base() {}

        public InvalidAmountOfBalanceException(string message) : base(message) {}
        
        public InvalidAmountOfBalanceException(string message, System.Exception inner) : base(message, inner) {}
        
        protected InvalidAmountOfBalanceException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
    }
}