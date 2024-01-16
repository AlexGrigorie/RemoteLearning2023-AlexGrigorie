using VendingMachine.Business.Interfaces;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Entities;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        private const string askForColumnNumber = "Please enter the number for your product";
        private const int invalidColumn = 0;
        private const string askForPaymentMethod = "Please select 1 for cash payment or 2 for card payment\n";
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

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            Display(askForPaymentMethod, ConsoleColor.Cyan);
            int.TryParse(Console.ReadLine(), out int amount);
            return amount;
        }
    }
}
