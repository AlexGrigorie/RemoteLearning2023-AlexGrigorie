using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InvalidCardNumberException : Exception
    {
        private const string message = "Your card number is not valid!";
        public InvalidCardNumberException() : base(message)
        {
        }
    }
}
