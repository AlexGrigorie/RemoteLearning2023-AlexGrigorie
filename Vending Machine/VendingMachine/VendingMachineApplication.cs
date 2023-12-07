using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainDisplay mainDisplay;

        private bool turnOffWasRequested;

        public bool UserIsLoggedIn { get; set; }

        public VendingMachineApplication(List<IUseCase> useCases, MainDisplay mainDisplay)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Run()
        {
            turnOffWasRequested = false;
            bool isABuyAction = false;

            while (!turnOffWasRequested)
            {
                try
                {
                    IEnumerable<IUseCase> availableUseCases = useCases.Where(x => x.CanExecute);
                    if (isABuyAction)
                    {
                        IUseCase buyUseCase = useCases.FirstOrDefault(x => x.Name == "buy");
                        buyUseCase.Execute();
                        isABuyAction = false;
                    }
                    else
                    {
                        IUseCase useCase = mainDisplay.ChooseCommand(availableUseCases);
                        useCase.Execute();
                    }

                }
                catch (CancelException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                    isABuyAction = false;
                }
                catch(InsufficientStockException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                    isABuyAction = false;
                }
                catch(InvalidColumnException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                    isABuyAction = true;
                }
                catch(InvalidPasswordException ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                }
                catch(Exception ex)
                {
                    mainDisplay.DisplayExceptionMessage(ex);
                    isABuyAction = false;
                }
            }
        }

        public void TurnOff()
        {
            turnOffWasRequested = true;
        }
    }
}