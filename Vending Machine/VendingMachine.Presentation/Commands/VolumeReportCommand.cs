using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCases;

namespace VendingMachine.Presentation.Commands
{
    internal class VolumeReportCommand : IApplicationCommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;
        public string Name => "volume";
        public string Description => "Generate report to see all quantity of products which were sold.";
        public bool CanExecute => authenticationService.IsUserLoggedIn;

        public VolumeReportCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Execute()
        {
           factory.Create<VolumeReportUseCase>().Execute();
        }
    }
}
