using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.UseCase
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