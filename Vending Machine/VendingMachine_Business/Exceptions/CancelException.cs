namespace VendingMachine_Business
{
    internal class CancelException : Exception
    {
        private const string message = "You canceled the buy process!";
        public CancelException() : base(message)
        {
        }
    }
}
