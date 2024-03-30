namespace VendingMachine_Business.Interfaces
{

    internal interface IBuyView
    {
        public int RequestProduct();
        public void DispenseProduct(string productName);
        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
