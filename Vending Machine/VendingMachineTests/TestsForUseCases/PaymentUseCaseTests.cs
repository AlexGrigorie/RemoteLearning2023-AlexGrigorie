using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class PaymentUseCaseTests
    {
        [TestMethod]
        public void HavingPaymentUseCase_WhenName_DisplayCorrectValue()
        {
            //Arrange
            var mockBuyView = new Mock<IBuyView>();
            var mockCardPayment = new Mock<IPaymentAlgorithm>();
            var mockCashPayment = new Mock<IPaymentAlgorithm>();
            List<IPaymentAlgorithm> algorithms = new List<IPaymentAlgorithm> { mockCashPayment.Object, mockCardPayment.Object };

            PaymentUseCase paymentUseCase = new PaymentUseCase(mockBuyView.Object, algorithms);

            //Act
            string name = paymentUseCase.Name;

            //Assert
            Assert.AreEqual("Payment", name);
        }
        [TestMethod]
        public void HavingPaymentUseCase_WhenDescription_DisplayCorrectValue()
        {
            //Arrange
            var mockBuyView = new Mock<IBuyView>();
            var mockCardPayment = new Mock<IPaymentAlgorithm>();
            var mockCashPayment = new Mock<IPaymentAlgorithm>();
            List<IPaymentAlgorithm> algorithms = new List<IPaymentAlgorithm> { mockCashPayment.Object, mockCardPayment.Object };

            PaymentUseCase paymentUseCase = new PaymentUseCase(mockBuyView.Object, algorithms);

            //Act
            string name = paymentUseCase.Description;

            //Assert
            Assert.AreEqual("Collect money from user", name);
        }
        [TestMethod]
        public void HavingPaymentUseCase_WhenExecute_ThenUseCashPaymentMethod()
        {
            //Arrange
            var mockBuyView = new Mock<IBuyView>();
            var mockCardPayment = new Mock<IPaymentAlgorithm>();
            var mockCashPayment = new Mock<IPaymentAlgorithm>();
            List<IPaymentAlgorithm> algorithms = new List<IPaymentAlgorithm> { mockCashPayment.Object, mockCardPayment.Object };

            PaymentUseCase paymentUseCase = new PaymentUseCase(mockBuyView.Object, algorithms);
            mockCardPayment.Setup(m => m.Name).Returns("cash");
            mockBuyView.Setup(m => m.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(1);

            //Act
            paymentUseCase.Execute(3);

            //Assert
            mockCashPayment.Verify(m => m.Run(3));
        }
        [TestMethod]
        public void HavingPaymentUseCase_WhenExecute_ThenUseCardPaymentMethod()
        {
            //Arrange
            var mockBuyView = new Mock<IBuyView>();
            var mockCardPayment = new Mock<IPaymentAlgorithm>();
            var mockCashPayment = new Mock<IPaymentAlgorithm>();
            List<IPaymentAlgorithm> algorithms = new List<IPaymentAlgorithm> { mockCashPayment.Object, mockCardPayment.Object };

            PaymentUseCase paymentUseCase = new PaymentUseCase(mockBuyView.Object, algorithms);
            mockCardPayment.Setup(m => m.Name).Returns("card");
            mockBuyView.Setup(m => m.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(2);

            //Act
            paymentUseCase.Execute(3);

            //Assert
            mockCardPayment.Verify(m => m.Run(3));
        }
        [TestMethod]
        public void HavingPaymentUseCase_WhenExecute_ThenThrowExceptionForInvalidPayment()
        {
            //Arrange
            var mockBuyView = new Mock<IBuyView>();
            var mockCardPayment = new Mock<IPaymentAlgorithm>();
            var mockCashPayment = new Mock<IPaymentAlgorithm>();
            List<IPaymentAlgorithm> algorithms = new List<IPaymentAlgorithm> { mockCashPayment.Object, mockCardPayment.Object };

            PaymentUseCase paymentUseCase = new PaymentUseCase(mockBuyView.Object, algorithms);
            mockBuyView.Setup(m => m.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(3);

            //Act & Assert
            Assert.ThrowsException<InvalidTypeOfPaymentException>(() => paymentUseCase.Execute(5));
        }
    }
}
