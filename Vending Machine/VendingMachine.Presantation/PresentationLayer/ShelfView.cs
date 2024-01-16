using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase, IShelfView
    {
        private const string title = "Available products";
        public void DisplayProducts(IEnumerable<Product> products)
        {
            DisplayLine(title, ConsoleColor.Cyan);
            foreach (Product product in products)
            {
                DisplayLine($"Id:{product.ColumnId} Name:{product.Name} Price:{product.Price}$ Quantity:{product.Quantity}", ConsoleColor.DarkCyan);
            }
        }
    }
}
