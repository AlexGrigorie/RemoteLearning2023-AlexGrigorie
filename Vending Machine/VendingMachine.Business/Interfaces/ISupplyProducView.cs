using VendingMachine.Business.Entities;

namespace VendingMachine.Business.Interfaces
{
    internal interface ISupplyProducView
    {
        QuantitySupply RequestProductQuantity();
        Product RequestNewProduct();
        void DisplaySuccessMessage();
    }
}
