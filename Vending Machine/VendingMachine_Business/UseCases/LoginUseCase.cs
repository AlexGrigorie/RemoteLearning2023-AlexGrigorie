namespace VendingMachine_Business.Interfaces
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IMainDisplay mainDisplay;

        public LoginUseCase(IAuthenticationService authenticationService, IMainDisplay mainDisplay)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Execute()
        {
            string password = mainDisplay.AskForPassword();
            authenticationService.Login(password);
        }
    }
}