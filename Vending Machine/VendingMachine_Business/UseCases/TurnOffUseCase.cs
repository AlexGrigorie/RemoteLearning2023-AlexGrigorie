namespace VendingMachine_Business.Interfaces
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly ITurnOffService turnOffService;

        public TurnOffUseCase(ITurnOffService turnOffService)
        {
            this.turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(turnOffService));
        }

        public void Execute()
        {
           turnOffService.TurnOff();
        }
    }
}