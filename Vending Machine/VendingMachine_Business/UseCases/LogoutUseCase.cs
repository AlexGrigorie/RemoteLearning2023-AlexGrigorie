namespace VendingMachine_Business.Interfaces
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => authenticationService.IsUserLoggedIn;

        public LogoutUseCase(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();
        }
    }
}