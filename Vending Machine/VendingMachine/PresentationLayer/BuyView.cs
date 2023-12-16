using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        private const string askForColumnNumber = "Please enter the number for your product";
        private const string askForPaymentMethod = "Please select 1 for cash payment or 2 for card payment\n";
        public int RequestProduct()
        {
            DisplayLine(askForColumnNumber, ConsoleColor.Cyan);
            int.TryParse(Console.ReadLine(), out int productId);
            return productId;
        }

        public void DispenseProduct(string productName)
        {
            DisplayLine($"Your {productName} was dispensed!", ConsoleColor.Cyan);
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            Display(askForPaymentMethod, ConsoleColor.Cyan);
            int.TryParse(Console.ReadLine(), out int amount);
            return amount;
        }
    }
}
