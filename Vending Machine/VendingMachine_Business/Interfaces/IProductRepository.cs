using VendingMachine_Business.Entities;

namespace VendingMachine_Business.Interfaces
{
    internal interface IProductRepository
    {
        Product GetByColumn(int columnId);
        IEnumerable<Product> GetAll();
        void IncreaseQuantity(QuantitySupply quantitySupply);
        void AddOrReplace(Product product);
    }
}
