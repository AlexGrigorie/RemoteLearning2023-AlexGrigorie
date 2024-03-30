using VendingMachine_Business.Interfaces;
using VendingMachine_Business.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class StockReportCommand : IApplicationCommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;
        public string Name => "stock";
        public string Description => "Generate the stock of products.";
        public bool CanExecute => authenticationService.IsUserLoggedIn;
        public StockReportCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Execute()
        {
            factory.Create<StockReportUseCase>().Execute();
        }
    }
}
