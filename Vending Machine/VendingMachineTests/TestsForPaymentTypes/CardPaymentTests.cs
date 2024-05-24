using Moq;
<<<<<<< HEAD
using VendingMachine_Business;
using VendingMachine_Business.Interfaces;
=======
using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.PaymentTypes;
>>>>>>> main

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
