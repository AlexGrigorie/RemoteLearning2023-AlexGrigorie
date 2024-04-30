using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCase;

namespace VendingMachine.Presentation.Commands
{
    internal class BuyCommand : IApplicationCommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;
        public string Name => "buy";

        public string Description => "Buy your favourite product";

        public bool CanExecute => !authenticationService.IsUserLoggedIn;

        public BuyCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Execute()
        {
            factory.Create<BuyUseCase>().Execute();
        }
    }
}
