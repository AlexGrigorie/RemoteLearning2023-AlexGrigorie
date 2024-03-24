using iQuest.VendingMachine.Entities;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IProductRepository
    {
        public Product GetByColumn(int columnId);
        public IEnumerable<Product> GetAll();
    }
}
