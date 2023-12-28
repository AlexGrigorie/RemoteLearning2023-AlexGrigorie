using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private List<IPaymentAlgorithm> paymentAlgorithms;
        private readonly IBuyView buyView;

        public PaymentUseCase(IBuyView buyView, IEnumerable<IPaymentAlgorithm> paymentAlgorithms)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = new List<IPaymentAlgorithm>(paymentAlgorithms);
        }

        public void Execute(float price)
        {
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
