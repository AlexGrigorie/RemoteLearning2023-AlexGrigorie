﻿using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;
using VendingMachine.Business.Interfaces;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class PaymentUseCaseTests
    {
        private Mock<IPaymentAlgorithm> mockCashPayment;
        private Mock<IPaymentAlgorithm> mockCardPayment;
        private Mock<IBuyView> mockBuyView;
        private List<IPaymentAlgorithm> algorithms;
        private PaymentUseCase paymentUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockCashPayment = new Mock<IPaymentAlgorithm>();
            mockCardPayment = new Mock<IPaymentAlgorithm>();
            mockBuyView = new Mock<IBuyView>();
            algorithms = new List<IPaymentAlgorithm> { mockCashPayment.Object, mockCardPayment.Object };
            paymentUseCase = new PaymentUseCase(mockBuyView.Object, algorithms);
        }
        [TestMethod]
        public void HavingPaymentUseCase_WhenExecute_ThenUseCashPaymentMethod()
        {
            mockCardPayment.Setup(m => m.Name).Returns("cash");
            mockBuyView.Setup(m => m.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(1);
            paymentUseCase.Execute(3);
            mockCashPayment.Verify(m => m.Run(3));
        }
        [TestMethod]
        public void HavingPaymentUseCase_WhenExecute_ThenUseCardPaymentMethod()
        {
            mockCardPayment.Setup(m => m.Name).Returns("card");
            mockBuyView.Setup(m => m.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(2);
            paymentUseCase.Execute(3);
            mockCardPayment.Verify(m => m.Run(3));
        }
        [TestMethod]
        public void HavingPaymentUseCase_WhenExecute_ThenThrowExceptionForInvalidPayment()
        {
            mockBuyView.Setup(m => m.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(3);
            Assert.ThrowsException<InvalidTypeOfPaymentException>(() => paymentUseCase.Execute(5));
        }
    }
}
