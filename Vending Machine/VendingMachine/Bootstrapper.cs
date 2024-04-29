using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentTypes;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.Services;
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
            TurnOffService turnOffService = new TurnOffService();
            AuthenticationService authenticationService = new AuthenticationService();
            ProductRepository productRepository = new ProductRepository();
            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();
            PaymentUseCase paymentUseCase = new PaymentUseCase(buyView, paymentAlgorithms);
            List<IUseCase> useCases = new List<IUseCase>();

            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay, turnOffService);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(authenticationService, mainDisplay),
                new LogoutUseCase(authenticationService),
                new LookUseCase(productRepository, shelfView),
                new BuyUseCase(authenticationService, buyView, productRepository, paymentUseCase),
                new TurnOffUseCase(authenticationService, turnOffService),
            });

            return vendingMachineApplication;
        }
    }
}