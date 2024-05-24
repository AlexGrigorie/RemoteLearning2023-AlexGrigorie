using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class SalesReportCommand : IApplicationCommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;
        public string Name => "sales";
        public string Description => "Generate the sales report for a specific period of time.";
        public bool CanExecute => authenticationService.IsUserLoggedIn;
        public SalesReportCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Execute()
        {
            factory.Create<SalesReportUseCase>().Execute();
        }
    }
}
