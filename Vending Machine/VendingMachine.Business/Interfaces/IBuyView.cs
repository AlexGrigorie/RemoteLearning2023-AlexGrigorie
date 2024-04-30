using VendingMachine.Business.Entities;
namespace VendingMachine.Business.Interfaces
{

    internal interface IBuyView
    {
        public int RequestProduct();
        public void DispenseProduct(string productName);
        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
