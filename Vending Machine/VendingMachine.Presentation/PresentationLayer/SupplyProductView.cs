using iQuest.VendingMachine.PresentationLayer;
using System.Text.RegularExpressions;
using VendingMachine.Business.Entities;
using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Presentation.PresentationLayer
{
    internal class SupplyProductView : DisplayBase, ISupplyProducView
    {
        private const string columnIdSupplyProduct ="Please insert the column id for your product\n";
        private const string quantitySupplyProduct ="Please insert quantity for your product\n";
        private const string nameProduct ="Please insert name for your product\n";
        private const string priceProduct ="Please insert price for your product\n";
        public void DisplaySuccessMessage()
        {
            Display("Your operation was finalized with successful!", color: ConsoleColor.Green);
        }
        public QuantitySupply RequestProductQuantity()
        {
            QuantitySupply quantitySupply = new QuantitySupply();
            quantitySupply.ColumnId = AskForProductColumnId();
            quantitySupply.Quantity = AskForProductQuantity();
            return quantitySupply;
        }

        public Product RequestNewProduct()
        {
            Product product = new Product();
            product.ColumnId = AskForProductColumnId();
            product.Name = AskforProductName();
            product.Price = AskForProductPrice();
            product.Quantity = AskForProductQuantity();
            return product;
        }

        private float AskForProductPrice()
        {
            Display(priceProduct, ConsoleColor.Cyan);
            string userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                throw new CancelSupplyExistingProductException();
            }

            if (!int.TryParse(userInput, out int coloumnId))
            {
                do
                {
                    Display("Price is incorrect!!!\nIt has to be a number.Try Again!\n", color: ConsoleColor.Red);
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        throw new CancelSupplyExistingProductException();
                    }
                } while (!int.TryParse(userInput, out coloumnId));
            }

            return coloumnId;
        }

        private string AskforProductName()
        {
            Display(nameProduct, ConsoleColor.Cyan);
            string regexPattern = @"^[a-zA-Z]+$";
            Regex regex = new Regex(regexPattern);
            string userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                throw new CancelSupplyExistingProductException();
            }

            if (!regex.IsMatch(userInput))
            {
                do
                {
                    Display("Name is incorrect!!!\nIt has to contain only letters.Try Again!\n", color: ConsoleColor.Red);
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        throw new CancelSupplyExistingProductException();
                    }
                } while (!regex.IsMatch(userInput));
            }

            return userInput;
        }

        private int AskForProductColumnId() 
        {
            Display(columnIdSupplyProduct, ConsoleColor.Cyan);
            string userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                throw new CancelSupplyExistingProductException();
            }

            if (!int.TryParse(userInput, out int coloumnId))
            {
                do
                {
                    Display("Column id incorrect!!!\nIt has to be a number.Try Again!\n", color: ConsoleColor.Red);
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        throw new CancelSupplyExistingProductException();
                    }
                } while (!int.TryParse(userInput, out coloumnId));
            }

            return coloumnId;
        }
        private int AskForProductQuantity()
        {
            Display(quantitySupplyProduct, ConsoleColor.Cyan);
            string userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                throw new CancelSupplyExistingProductException();
            }

            if (!int.TryParse(userInput, out int quantity))
            {
                do
                {
                    Display("Invalid quantity!!!\nIt has to be a number.Try Again!\n", color: ConsoleColor.Red);
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        throw new CancelSupplyExistingProductException();
                    }
                } while (!int.TryParse(userInput, out quantity));
            }

            return quantity;
        }
    }
}
