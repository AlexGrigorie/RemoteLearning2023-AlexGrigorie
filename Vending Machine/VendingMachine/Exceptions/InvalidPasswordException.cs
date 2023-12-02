using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InvalidPasswordException : Exception
    {
        private const string message = "Invalid password!";
        public InvalidPasswordException() : base(message)
        {
        }
    }
}
