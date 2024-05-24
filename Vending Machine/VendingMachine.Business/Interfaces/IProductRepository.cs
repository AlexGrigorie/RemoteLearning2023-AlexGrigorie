using VendingMachine.Business.Entities;

namespace VendingMachine.Business.Interfaces
{
    internal interface IProductRepository
    {
        public Product GetByColumn(int columnId);
        public IEnumerable<Product> GetAll();
        public void IncreaseQuantity(QuantitySupply quantitySupply);
        public void AddProduct(Product product);

    }
}
