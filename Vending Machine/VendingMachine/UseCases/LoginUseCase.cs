using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IVendingMachineApplication application;
        private readonly IMainDisplay mainDisplay;

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !application.UserIsLoggedIn;

        public LoginUseCase(IVendingMachineApplication application, IMainDisplay mainDisplay)
        {
            this.application = application ?? throw new ArgumentNullException(nameof(application));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Execute()
        {
            string password = mainDisplay.AskForPassword();

                if (password == "supercalifragilisticexpialidocious")
                    application.UserIsLoggedIn = true;
                else
                    throw new InvalidPasswordException();
        }
    }
}