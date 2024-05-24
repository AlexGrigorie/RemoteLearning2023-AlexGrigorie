namespace VendingMachine.Business.Exceptions
{
    internal class InvalidColumnIdException : Exception
    {
        private const string message = "This column id doesn't exist!";
        public InvalidColumnIdException() : base(message)
        {
        }
    }
}
