namespace iQuest.VendingMachine.Interfaces
{
    internal interface IPaymentUseCase
    {
        public void Execute(float price);
    }
}
