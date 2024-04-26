using VendingMachine_Business;
using VendingMachine_Business.Interfaces;


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
    }
}
