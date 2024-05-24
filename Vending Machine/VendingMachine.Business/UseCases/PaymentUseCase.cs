using VendingMachine.Business.Entities;
using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private const string customMessagePaymentUseCase = "The user has made a transaction";
        private List<IPaymentAlgorithm> paymentAlgorithms;
        private readonly IBuyView buyView;
        private readonly ILoggerService loggerService;

        public PaymentUseCase(IBuyView buyView, IEnumerable<IPaymentAlgorithm> paymentAlgorithms, ILoggerService loggerService)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = new List<IPaymentAlgorithm>(paymentAlgorithms);
            this.loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }

        public void Execute(float price)
        {
            loggerService.LogInformation(customMessagePaymentUseCase);
            var selectedPayment = GetSelectedPaymentMethod();
            if (selectedPayment == null)
            {
                throw new InvalidTypeOfPaymentException();
            }
            selectedPayment.Run(price);

        }

        private IPaymentAlgorithm GetSelectedPaymentMethod()
        {
            var paymentMethods = SetPaymentsMethods();
            var getIdForPaymentMethod = buyView.AskForPaymentMethod(paymentMethods);
            foreach (var paymentMethod in paymentMethods)
            {
                if (paymentMethod.Id == getIdForPaymentMethod)
                {
                    return paymentAlgorithms[getIdForPaymentMethod - 1];
                }
            }
            return null;
        }

        private List<PaymentMethod> SetPaymentsMethods()
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
            int paymentId = 0;

            foreach (var method in paymentAlgorithms)
            {
                paymentMethods.Add(new PaymentMethod { Id = ++paymentId, Name = method.Name });
            }

            return paymentMethods;
        }
    }
}
