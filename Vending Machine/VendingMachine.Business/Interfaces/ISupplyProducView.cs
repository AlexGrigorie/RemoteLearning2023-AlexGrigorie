using VendingMachine.Business.Entities;

namespace VendingMachine.Business.Interfaces
{
    internal interface ISupplyProducView
    {
        public QuantitySupply GetProductQuantity();
        public Product GetNewProduct();
        public void DisplaySuccessMessage();
    }
}
