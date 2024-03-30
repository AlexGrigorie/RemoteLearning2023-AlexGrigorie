namespace VendingMachine_Business.Interfaces
{
    internal interface IUseCaseFactory
    {
        T Create<T>() where T : IUseCase;
    }
}
