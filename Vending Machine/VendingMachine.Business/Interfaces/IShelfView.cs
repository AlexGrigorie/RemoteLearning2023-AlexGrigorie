using VendingMachine.Business.Entities;

namespace VendingMachine.Business.Interfaces
{
    internal interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products);
    }
}
