using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InvalidColumnException : Exception
    {
        private const string message = "Invalid column!";
        public InvalidColumnException() : base(message)
        {
        }
    }
}
