using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentTypes;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests.TestsForPaymentTypes
{
    [TestClass]
    public class CardPaymentTests
    {
        private Mock<ICardPaymentTerminal> mockCardPaymentTerminal;
        private CardPayment cardPayment;

        [TestInitialize]
        public void SetupTest()
        {
            mockCardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            cardPayment = new CardPayment(mockCardPaymentTerminal.Object);
        }
        [TestMethod]
        public void HavingCardPayment_WhenName_DisplayCorrectName()
        {
            string name = cardPayment.Name;
            Assert.AreEqual("Card", name);
        }
        [TestMethod]
        public void HavingCardPayment_WhenRunAndInvalidCardNumber_ThenThrowInvalidCardNumberException()
        {
            mockCardPaymentTerminal.Setup(m => m.AskForCardNumber()).Returns("45123456789739852");
            Assert.ThrowsException<InvalidCardNumberException>(() => cardPayment.Run(2.4f));
        }
    }
}
