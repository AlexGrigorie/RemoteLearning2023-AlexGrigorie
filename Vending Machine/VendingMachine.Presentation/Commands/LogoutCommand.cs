using VendingMachine_Business.Interfaces;

namespace VendingMachine.Presentation.Commands
{
    internal class LogoutCommand : IApplicationCommand
    {
        private readonly IUseCaseFactory factory;
        private readonly IAuthenticationService authenticationService;
        public string Name => "logout";
        public string Description => "Restrict access to administration buttons.";
        public bool CanExecute => authenticationService.IsUserLoggedIn;
        public LogoutCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Execute()
        {
            factory.Create<LogoutUseCase>().Execute();
        }
    }
}
