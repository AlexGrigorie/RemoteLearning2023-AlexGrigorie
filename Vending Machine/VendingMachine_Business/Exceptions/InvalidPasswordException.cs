namespace VendingMachine_Business
{
    internal class InvalidPasswordException : Exception
    {
        private const string message = "Invalid password!";
        public InvalidPasswordException() : base(message)
        {
        }
    }
}
