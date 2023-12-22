using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly ITurnOffService turnOffService;
        private readonly IAuthenticationService authenticationService;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => authenticationService.UserIsLoggedIn;

        public TurnOffUseCase(IAuthenticationService authenticationService, ITurnOffService turnOffService)
        {
            this.authenticationService = authenticationService;
            this.turnOffService = turnOffService;
        }

        public void Execute()
        {
           turnOffService.TurnOff();
        }
    }
}