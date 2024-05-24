using Autofac;
using VendingMachine.Business.Interfaces;

namespace iQuest.VendingMachine
{
    internal class UseCaseFactory : IUseCaseFactory
    {
        private IComponentContext context;

        public UseCaseFactory(IComponentContext context)
        {
            this.context = context;
        }

        public T Create<T>() where T : IUseCase
        {
            return context.Resolve<T>();
        }
    }
}
