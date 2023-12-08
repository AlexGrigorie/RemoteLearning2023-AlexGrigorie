using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Helper;
using iQuest.VendingMachine.Repository;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase
    {
        private const string askForColumnNumber = "Please enter the number for your product";
        private readonly ProductRepository productRepository;
        private readonly MainDisplay mainDisplay;

        public BuyView(ProductRepository productRepository, MainDisplay mainDisplay)
        {
            this.productRepository = productRepository;
            this.mainDisplay = mainDisplay;

        }
        public int RequestProduct()
        {
            int productId = 0;
            while (true)
            {
                try
                {
                    DisplayLine(askForColumnNumber, ConsoleColor.Cyan);
                    int.TryParse(Console.ReadLine(), out productId);

                    if (productId == StatusProduct.CancelBuyProduct) throw new CancelException();

                    Product product = productRepository.GetByColumn(productId);
                    if (product == null)
                    {
                        throw new InvalidColumnException();
                    }
                    break;
                }
                catch (CancelException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                    break;
                }
                catch (InvalidColumnException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
            }
            return productId;

        }

        public void DispenseProduct(string productName)
        {
            DisplayLine($"Your {productName} was dispensed!", ConsoleColor.Cyan);
        }
    }
}
