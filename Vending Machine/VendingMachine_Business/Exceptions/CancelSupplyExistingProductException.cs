namespace VendingMachine_Business.Exceptions
{
    internal class CancelSupplyExistingProductException : Exception
    {
        private const string message = "You canceled the increase quantity process!";
        public CancelSupplyExistingProductException() : base(message)
        {
        }
    }
}
