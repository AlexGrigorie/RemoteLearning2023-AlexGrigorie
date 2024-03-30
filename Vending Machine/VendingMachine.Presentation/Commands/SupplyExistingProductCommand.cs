using VendingMachine_Business.Interfaces;
using VendingMachine_Business.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class SupplyExistingProductCommand : IApplicationCommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;
        public string Name => "increaseQuantity";
        public string Description => "Increase quantity for an existing product.";
        public bool CanExecute => authenticationService.IsUserLoggedIn;

        public SupplyExistingProductCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService;
            this.factory = factory;
        }
        public void Execute()
        {
            factory.Create<SupplyExistingProductUseCase>().Execute();
        }
    }
}
