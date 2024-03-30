namespace VendingMachine_Business.Interfaces
{
    internal class TurnOffUseCase : IUseCase
    {
        private const string customMessageUserExist = "User has closed the app and lives the life.";
        private readonly ITurnOffService turnOffService;
        private readonly ILoggerService loggerService;

        public TurnOffUseCase(ITurnOffService turnOffService, ILoggerService loggerService)
        {
            this.turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(turnOffService));
            this.loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }

        public void Execute()
        {
           loggerService.LogInformation(customMessageUserExist);
           turnOffService.TurnOff();
        }
    }
}