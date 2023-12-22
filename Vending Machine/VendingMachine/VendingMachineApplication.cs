using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly IMainDisplay mainDisplay;
        private readonly ITurnOffService turnOffService;

        public VendingMachineApplication(List<IUseCase> useCases, IMainDisplay mainDisplay, ITurnOffService turnOffService)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Run()
        {
            while (!turnOffService.TurnOffWasRequested)
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
                catch(Exception ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
            }
        }
    }
}