namespace VendingMachine.Business.Exceptions
{
    internal class InvalidTypeOfPaymentException : Exception
    {
        private const string message = "This type of payment does not exist!";
        public InvalidTypeOfPaymentException() : base(message)
        {
        }
    }
}
