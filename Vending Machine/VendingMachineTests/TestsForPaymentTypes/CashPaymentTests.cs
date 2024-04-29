using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentTypes;
using Moq;

namespace iQuest.VendingMachineTests.TestsForPaymentTypes
{
    [TestClass]
    public class CashPaymentTests
    {
        private Mock<ICashPaymentTerminal> mockCashPaymentTerminal;
        private CashPayment cashPayment;

        [TestInitialize]
        public void SetupTest()
        {
            mockCashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            cashPayment = new CashPayment(mockCashPaymentTerminal.Object);
        }
        [TestMethod]
        public void HavingCashPayment_WhenName_DisplayCorrectName()
        {
            mockCashPaymentTerminal.Setup(m => m.AskForMoney()).Returns(2);
            string name = cashPayment.Name;
            Assert.AreEqual("Cash", name);
        }
        [TestMethod]
        public void HavingCashPayment_WhenRun_GiveChangeToUser()
        {
            mockCashPaymentTerminal.Setup(m => m.AskForMoney()).Returns(10);
            cashPayment.Run(2);
            mockCashPaymentTerminal.Verify(m => m.GiveBackChange(8), Times.Once());
        }
        [TestMethod]
        public void HavingCashPayment_WhenRun_ThrowInvalidMoneyException()
        {
            mockCashPaymentTerminal.Setup(m => m.AskForMoney()).Returns(100);
            Assert.ThrowsException<InvalidMoneyException>(() => cashPayment.Run(2));
        }
        [TestMethod]
        public void HavingCashPayment_WhenRun_ThrowCancelException()
        {
            mockCashPaymentTerminal.Setup(m => m.AskForMoney()).Throws(new CancelException());
            Assert.ThrowsException<CancelException>(() => cashPayment.Run(2));
        }
        public void HavingCashPayment_WhenRun_ThrowInvalidMoney()
        {
            mockCashPaymentTerminal.Setup(m => m.AskForMoney()).Throws(new InvalidMoneyException());
            Assert.ThrowsException<InvalidMoneyException>(() => cashPayment.Run(2));
        }
    }
}
