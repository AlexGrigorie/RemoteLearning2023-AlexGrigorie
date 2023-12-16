using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentTypes;
using Moq;

namespace iQuest.VendingMachineTests.TestsForPaymentTypes
{
    [TestClass]
    public class CashPaymentTests
    {
        [TestMethod]
        public void HavingCashPayment_WhenName_DisplayCorrectValue()
        {
            //Arrange
            var mockCashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            CashPayment cashPayment = new CashPayment(mockCashPaymentTerminal.Object);
            mockCashPaymentTerminal.Setup(m => m.AskForMoney()).Returns(2);

            //Act
            string name = cashPayment.Name;

            //Assert
            Assert.AreEqual("Cash", name);
        }

        [TestMethod]
        public void HavingCashPayment_WhenRun_GiveChangeToUser()
        {
            //Arrange
            var mockCashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            CashPayment cashPayment = new CashPayment(mockCashPaymentTerminal.Object);
            mockCashPaymentTerminal.Setup(m => m.AskForMoney()).Returns(10);

            //Act
            cashPayment.Run(2);

            //Assert
            mockCashPaymentTerminal.Verify(m => m.GiveBackChange(8), Times.Once());
        }
        [TestMethod]
        public void HavingCashPayment_WhenRun_ThrowInvalidMoneyException()
        {
            //Arrange
            var mockCashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            CashPayment cashPayment = new CashPayment(mockCashPaymentTerminal.Object);
            mockCashPaymentTerminal.Setup(m => m.AskForMoney()).Returns(100);

            //Act & Assert
            Assert.ThrowsException<InvalidMoneyException>(() => cashPayment.Run(2));
        }
    }
}
