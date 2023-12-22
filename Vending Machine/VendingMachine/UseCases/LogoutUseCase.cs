using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => authenticationService.UserIsLoggedIn;

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