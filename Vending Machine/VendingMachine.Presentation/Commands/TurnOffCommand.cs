using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCase;

namespace VendingMachine.Presentation.Commands
{
    internal class TurnOffCommand : IApplicationCommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => authenticationService.IsUserLoggedIn;
        public TurnOffCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Execute()
        {
            factory.Create<TurnOffUseCase>().Execute();
        }
    }
}
