using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.UseCases;
using System.Collections.Generic;

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
            BuyView buyView = new BuyView();
            List<IUseCase> useCases = new List<IUseCase>();

            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(vendingMachineApplication, mainDisplay),
                new LogoutUseCase(vendingMachineApplication),
                new LookUseCase(productRepository, shelfView),
                new BuyUseCase(vendingMachineApplication, buyView, productRepository),
                new TurnOffUseCase(vendingMachineApplication)
            });

            return vendingMachineApplication;
        }
    }
}