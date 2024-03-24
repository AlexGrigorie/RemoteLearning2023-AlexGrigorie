﻿namespace iQuest.VendingMachine.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        private const string message = "Insufficient stock for your product!";
        public InsufficientStockException() : base(message)
        {
        }
    }
}
