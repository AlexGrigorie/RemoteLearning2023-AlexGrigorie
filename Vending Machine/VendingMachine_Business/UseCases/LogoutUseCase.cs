namespace VendingMachine_Business.Interfaces
{
    internal class LogoutUseCase : IUseCase
    {
        private const string customMessageLogout = "The user has logged out.";
        private readonly IAuthenticationService authenticationService;
        private readonly ILoggerService loggerService;

        public LogoutUseCase(IAuthenticationService authenticationService, ILoggerService loggerService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }

        public void Execute()
        {
            loggerService.LogInformation(customMessageLogout);
            authenticationService.Logout();
        }
    }
}