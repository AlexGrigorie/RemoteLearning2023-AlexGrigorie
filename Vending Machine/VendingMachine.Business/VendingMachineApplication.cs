using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly IEnumerable<IUseCase> useCases;
        private readonly IMainDisplay mainDisplay;
        private readonly ITurnOffService turnOffService;

        public VendingMachineApplication(IEnumerable<IUseCase> useCases, IMainDisplay mainDisplay, ITurnOffService turnOffService)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Run()
        {
            while (!turnOffService.WasTurnOffRequested)
            {
                try
                {
                    IEnumerable<IUseCase> availableUseCases = useCases.Where(x => x.CanExecute);
                    IUseCase useCase = mainDisplay.ChooseCommand(availableUseCases);
                    useCase.Execute();

                }
                catch (CancelException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InsufficientStockException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidColumnException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidPasswordException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidCardNumberException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidMoneyException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(InvalidTypeOfPaymentException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(Exception ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
            }
        }
    }
}