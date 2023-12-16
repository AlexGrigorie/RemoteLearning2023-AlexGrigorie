namespace iQuest.VendingMachine.Interfaces
{
    internal interface IPaymentAlgorithm
    {
        public string Name { get; }
        public void Run(float price);
    }
}
