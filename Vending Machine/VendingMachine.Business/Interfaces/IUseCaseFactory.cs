namespace VendingMachine.Business.Interfaces
{
    internal interface IUseCaseFactory
    {
        T Create<T>() where T : IUseCase;
    }
}
