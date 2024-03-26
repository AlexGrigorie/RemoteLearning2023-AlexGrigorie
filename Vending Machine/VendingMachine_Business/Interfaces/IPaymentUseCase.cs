namespace VendingMachine_Business.Interfaces
{
    internal interface IPaymentUseCase
    {
        public void Execute(float price);
    }
}
