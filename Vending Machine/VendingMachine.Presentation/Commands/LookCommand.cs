using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class LookCommand : IApplicationCommand
    {
        private readonly IUseCaseFactory factory;
        public string Name => "look";
        public string Description => "Display all available products.";
        public bool CanExecute => true;
        public LookCommand(IUseCaseFactory factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Execute()
        {
            factory.Create<LookUseCase>().Execute();
        }
    }
}
