using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly IVendingMachineApplication application;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => application.UserIsLoggedIn;

        public TurnOffUseCase(IVendingMachineApplication application)
        {
            this.application = application;
        }

        public void Execute()
        {
            application.TurnOff();
        }
    }
}