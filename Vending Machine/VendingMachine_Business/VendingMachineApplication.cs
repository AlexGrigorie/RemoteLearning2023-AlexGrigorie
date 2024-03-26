﻿using VendingMachine_Business.Exceptions;

namespace VendingMachine_Business.Interfaces
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly IEnumerable<IApplicationCommand> useCases;
        private readonly IMainDisplay mainDisplay;
        private readonly ITurnOffService turnOffService;

        public VendingMachineApplication(IEnumerable<IApplicationCommand> useCases, IMainDisplay mainDisplay, ITurnOffService turnOffService)
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
                    IEnumerable<IApplicationCommand> availableUseCases = useCases.Where(x => x.CanExecute);
                    IApplicationCommand useCase = mainDisplay.ChooseCommand(availableUseCases);
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
                catch (CancelSupplyExistingProductException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }                
                catch (InvalidColumnIdException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch (Exception ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
            }
        }
    }
}