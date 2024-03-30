namespace VendingMachine_Business
{
    internal class InsufficientStockException : Exception
    {
        private const string message = "Insufficient stock for your product!";
        public InsufficientStockException() : base(message)
        {
        }
    }
}
