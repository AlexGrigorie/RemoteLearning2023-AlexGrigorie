using VendingMachine.Business.Entities;
using VendingMachine.Business.Interfaces;

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
                DisplayLine($"Id:{product.ColumnId} Name:{product.Name} Price:{product.Price}lei Quantity:{product.Quantity}", ConsoleColor.DarkCyan);
            }
        }
    }
}
