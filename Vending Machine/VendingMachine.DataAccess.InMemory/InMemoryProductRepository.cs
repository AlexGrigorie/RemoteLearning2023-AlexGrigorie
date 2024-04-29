using VendingMachine.Business.Entities;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.DataAccess.InMemory
{
    internal class InMemoryProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product>();

        public InMemoryProductRepository()
        {
            Product apple = new Product();
            apple.ColumnId = 11;
            apple.Name = "Apple";
            apple.Price = 2;
            apple.Quantity = 1;

            Product orange = new Product();
            orange.ColumnId = 12;
            orange.Name = "Orange";
            orange.Price = 4;
            orange.Quantity = 7;

            Product grape = new Product();
            grape.ColumnId = 13;
            grape.Name = "Grape";
            grape.Price = 2.99f;
            grape.Quantity = 12;

            Product banana = new Product();
            banana.ColumnId = 14;
            banana.Name = "Banana";
            banana.Price = 2.5f;
            banana.Quantity = 10;

            products.Add(apple);
            products.Add(orange);
            products.Add(grape);
            products.Add(banana);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product GetByColumn(int columnId)
        {
            Product product = products.Find(p => p.ColumnId == columnId);
            return product;
        }
    }
}
