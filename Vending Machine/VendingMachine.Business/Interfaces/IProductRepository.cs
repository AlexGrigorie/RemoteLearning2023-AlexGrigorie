using VendingMachine.Business.Entities;

namespace VendingMachine.Business.Interfaces
{
    internal interface IProductRepository
    {
        public Product GetByColumn(int columnId);
        public IEnumerable<Product> GetAll();
        void IncreaseQuantity(QuantitySupply quantitySupply);
        void AddOrReplace(Product product);
    }
}
