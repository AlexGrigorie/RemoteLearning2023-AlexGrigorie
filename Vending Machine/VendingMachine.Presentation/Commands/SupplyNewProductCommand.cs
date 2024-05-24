using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class SupplyNewProductCommand : IApplicationCommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;
        public string Name => "addNewProduct";
        public string Description => "Add or replace a product.";
        public bool CanExecute => authenticationService.IsUserLoggedIn;

        public SupplyNewProductCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService;
            this.factory = factory;
        }

        public void Execute()
        {
            factory.Create<SupplyNewProductUseCase>().Execute();
        }
    }
}
