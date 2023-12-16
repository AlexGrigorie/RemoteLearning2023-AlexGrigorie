using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly IVendingMachineApplication application;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => application.UserIsLoggedIn;

        public LogoutUseCase(IVendingMachineApplication application)
        {
            this.application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public void Execute()
        {
            application.UserIsLoggedIn = false;
        }
    }
}