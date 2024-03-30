namespace VendingMachine_Business
{
    internal class InvalidMoneyException : Exception
    {
        private const string message = "Your coin or banknote is invalid!";
        public InvalidMoneyException() : base(message)
        {
        }
    }
}
