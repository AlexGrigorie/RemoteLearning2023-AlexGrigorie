using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase
    {
        private const string askForColumnNumber = "Please enter the number for your product";
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
    }
}
