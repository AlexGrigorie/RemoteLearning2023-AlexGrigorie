using iQuest.VendingMachine.Entities;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.View
{
    internal class ShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            Console.WriteLine("Available products");
            Console.WriteLine();
            foreach (Product product in products)
            {
                Console.WriteLine($"Product:{product.Name}  Price:{product.Price}$ Quantity:{product.Quantity}");
            }
        }
    }
}
