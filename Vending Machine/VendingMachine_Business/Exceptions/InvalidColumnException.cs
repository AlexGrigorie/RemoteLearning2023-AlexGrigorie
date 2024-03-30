namespace VendingMachine_Business
{
    internal class InvalidColumnException : Exception
    {
        private const string message = "Invalid column!";
        public InvalidColumnException() : base(message)
        {
        }
    }
}
