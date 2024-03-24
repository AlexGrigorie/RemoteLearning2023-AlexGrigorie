namespace VendingMachine_Business.Interfaces
{
    internal interface IProductRepository
    {
        public Product GetByColumn(int columnId);
        public IEnumerable<Product> GetAll();
    }
}
