namespace VendingMachine.Business.Exceptions
{
    internal class ConflictDatesException : Exception
    {
        private const string message = "Start date can not be after end date!";
        public ConflictDatesException() : base(message)
        {
        }
    }
}
