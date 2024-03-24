namespace VendingMachine_Business.Interfaces
{
    internal interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products);
    }
}
