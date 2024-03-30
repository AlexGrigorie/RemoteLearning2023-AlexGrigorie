namespace VendingMachine_Business.Interfaces
{
    internal class LoginUseCase : IUseCase
    {
        private const string customMessageWhenUserLogin = "User logged in!";
        private readonly IAuthenticationService authenticationService;
        private readonly IMainDisplay mainDisplay;
        private readonly ILoggerService loggerService;
        public LoginUseCase(IAuthenticationService authenticationService, IMainDisplay mainDisplay, ILoggerService loggerService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }

        public void Execute()
        {
            loggerService.LogInformation(customMessageWhenUserLogin);
            string password = mainDisplay.AskForPassword();
            authenticationService.Login(password);
        }
    }
}