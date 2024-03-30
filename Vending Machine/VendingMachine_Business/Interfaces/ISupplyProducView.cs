using VendingMachine_Business.Entities;

namespace VendingMachine_Business.Interfaces
{
    internal interface ISupplyProducView
    {
        QuantitySupply RequestProductQuantity();
        Product RequestNewProduct();
        void DisplaySuccessMessage();
    }
}
