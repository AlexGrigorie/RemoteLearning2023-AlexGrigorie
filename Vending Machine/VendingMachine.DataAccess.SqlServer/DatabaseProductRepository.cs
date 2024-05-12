using VendingMachine.Business.Entities;
using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.DataAccess.SqlServer
{
    internal class DatabaseProductRepository : IProductRepository
    {     
        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
            using (var dbContext = new ApplicationDbContextFactory().CreateDbContext())
            {
                products = dbContext.Products.ToList();
            }
            return products;
        }

        public Product GetByColumn(int columnId)
        {
            Product product = null;
            using (var dbContext = new ApplicationDbContextFactory().CreateDbContext())
            {
                 product = dbContext.Products.FirstOrDefault(p => p.ColumnId == columnId);
            }
            return product;
        }

        public void IncreaseQuantity(QuantitySupply quantitySupply)
        {
            using(var dbContext = new ApplicationDbContextFactory().CreateDbContext())
            {
                var product = dbContext.Products.FirstOrDefault(p => p.ColumnId == quantitySupply.ColumnId);
                if(product == null) 
                {
                    throw new InvalidColumnIdException();
                }
                product.Quantity += quantitySupply.Quantity;
                dbContext.SaveChanges();
            }
        }

        public void AddOrReplace(Product product) 
        {
            using (var dbContext = new ApplicationDbContextFactory().CreateDbContext())
            {
                var existingProduct = dbContext.Products.FirstOrDefault(p => p.ColumnId == product.ColumnId);
                if (existingProduct == null)
                {
                    dbContext.Products.Add(product);
                    dbContext.SaveChanges();
                }
                else 
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Quantity += product.Quantity;
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
