using VendingMachine_Business.Exceptions;

namespace VendingMachine_Business.Interfaces
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private const string customMessageAppStarts = "The application comes to life.";
        private readonly IEnumerable<IApplicationCommand> useCases;
        private readonly IMainDisplay mainDisplay;
        private readonly ITurnOffService turnOffService;
        private readonly ILoggerService logger;

        public VendingMachineApplication(IEnumerable<IApplicationCommand> useCases, IMainDisplay mainDisplay, ITurnOffService turnOffService, ILoggerService logger)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Run()
        {
            while (!turnOffService.WasTurnOffRequested)
            {
                try
                {
                    logger.LogInformation(customMessageAppStarts);
                    IEnumerable<IApplicationCommand> availableUseCases = useCases.Where(x => x.CanExecute);
                    IApplicationCommand useCase = mainDisplay.ChooseCommand(availableUseCases);
                    useCase.Execute();

                }
                catch (CancelException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InsufficientStockException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidColumnException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidPasswordException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidCardNumberException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidMoneyException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidTypeOfPaymentException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch (CancelSupplyExistingProductException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }                
                catch (InvalidColumnIdException ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex);
                    mainDisplay.DisplayExceptionMessage(ex);
                }
            }
        }
    }
}