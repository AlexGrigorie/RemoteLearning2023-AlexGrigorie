using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentTypes;
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
            CardPayment cardPayment = new CardPayment(new CardPaymentTerminal());
            CashPayment cashPayment = new CashPayment(new CashPaymentTerminal());
            List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm> {cashPayment, cardPayment};
            MainDisplay mainDisplay = new MainDisplay();
            ProductRepository productRepository = new ProductRepository();
            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();
            PaymentUseCase paymentUseCase = new PaymentUseCase(buyView, paymentAlgorithms);
            List<IUseCase> useCases = new List<IUseCase>();

            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(vendingMachineApplication, mainDisplay),
                new LogoutUseCase(vendingMachineApplication),
                new LookUseCase(productRepository, shelfView),
                new BuyUseCase(vendingMachineApplication, buyView, productRepository, paymentUseCase),
                new TurnOffUseCase(vendingMachineApplication),
            });

            return vendingMachineApplication;
        }
    }
}