using VendingMachine_Business.Interfaces;
using VendingMachine_Business.Reports.Volume;
using Product = VendingMachine_Business.Reports.Stock.Product;
using ProductStock = VendingMachine_Business.Entities.Product;

namespace VendingMachine_Business.Reports.Sales
{
    internal class SalesRepository : ISalesRepository
    {
        private readonly IEnumerable<Sales> sales = new List<Sales>
        {
            new Sales
            {
                 Product = new ProductStock()
                {
                      ColumnId = 11,
                      Name = "Apple",
                      Price= 2,
                      Quantity = 1,
                },
                PaymentMethod = "cash",
                SaleDate = new DateTime(2023,6,2)
            },

            new Sales
            {
                 Product = new ProductStock()
                {
                    ColumnId = 12,
                    Name = "Orange",
                    Price = 4,
                    Quantity = 5,
                },
                 PaymentMethod = "card",
                 SaleDate = new DateTime(2023,1,4)
            },

            new Sales
            {
                 Product = new ProductStock()
                {
                    ColumnId = 13,
                    Name = "Grape",
                    Price = 2.99f,
                    Quantity = 10,
                },
                 PaymentMethod = "card",
                 SaleDate = new DateTime(2023,1,6)
            },

             new Sales
            {
                 Product = new ProductStock()
                {
                    ColumnId = 14,
                    Name = "Banana",
                    Price = 2.5f,
                    Quantity = 7,
                },
                PaymentMethod = "card",
                SaleDate = new DateTime(2022,6,13)
            },
        };
        public IEnumerable<Sales> GetAllSales()
        {
            return sales;
        }
        public IEnumerable<Product> GetGroupedByProduct(TimeInterval timeInterval)
        {
            return sales.Where(x => x.SaleDate.Date >= timeInterval.StartDate || x.SaleDate.Date >= timeInterval.EndDate)
                                                   .GroupBy(x => x.Product.Name)
                                                   .Select(x => new Product { Name = x.Key, Quantity = x.Sum(q => q.Product.Quantity) });
        }
    }
}
