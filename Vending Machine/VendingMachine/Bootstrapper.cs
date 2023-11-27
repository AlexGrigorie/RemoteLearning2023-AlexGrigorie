using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.UseCases;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            MainDisplay mainDisplay = new MainDisplay();
            ProductRepository productRepository = new ProductRepository();
            ShelfView shelfView = new ShelfView();
            List<IUseCase> useCases = new List<IUseCase>();

            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(vendingMachineApplication, mainDisplay),
                new LookUseCase(productRepository, shelfView),
                new LogoutUseCase(vendingMachineApplication),
                new TurnOffUseCase(vendingMachineApplication)
            });

            return vendingMachineApplication;
        }
    }
}