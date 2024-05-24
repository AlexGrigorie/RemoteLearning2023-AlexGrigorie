namespace VendingMachine.Business.Interfaces
{
    internal interface IPaymentAlgorithm
    {
        public string Name { get; }
        public void Run(float price);
    }
}
