using VendingMachine_Business.Interfaces;

namespace VendingMachine.Presentation.Commands
{
    internal class LoginCommand : IApplicationCommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !authenticationService.IsUserLoggedIn;

        public LoginCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Execute()
        {
            factory.Create<LoginUseCase>().Execute();
        }
    }
}
