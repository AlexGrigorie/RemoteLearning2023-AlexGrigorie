using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Helper;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        private const string askForColumnNumber = "Please enter the number for your product";
        private const int invalidColumn = 0;
        public int RequestProduct()
        {
            DisplayLine(askForColumnNumber, ConsoleColor.Cyan);
            string userInput = Console.ReadLine();
            if(string.IsNullOrEmpty(userInput))
            {
                throw new CancelException();
            }
            int.TryParse(userInput, out int productId);
            if(productId == invalidColumn)
            {
                throw new InvalidColumnException();
            }
            return productId;
        }

        public void DispenseProduct(string productName)
        {
            DisplayLine($"Your {productName} was dispensed!", ConsoleColor.Cyan);
        }
    }
}
