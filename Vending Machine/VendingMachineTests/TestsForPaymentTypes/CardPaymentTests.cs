using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentTypes;
using Moq;

namespace iQuest.VendingMachineTests.TestsForPaymentTypes
{
    [TestClass]
    public class CardPaymentTests
    {
        [TestMethod]
        public void HavingCardPayment_WhenName_DisplayCorrectValue()
        {
            //Arrange
            var mockCardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            CardPayment cardPayment = new CardPayment(mockCardPaymentTerminal.Object);

            //Act
            string name = cardPayment.Name;

            //Assert
            Assert.AreEqual("Card", name);
        }
        [TestMethod]
        public void HavingCardPayment_WhenRunAndInvalidCardNumber_ThenThrowInvalidCardNumberException()
        {
            //Arrange
            var mockCardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            CardPayment cardPayment = new CardPayment(mockCardPaymentTerminal.Object);
            mockCardPaymentTerminal.Setup(m => m.AskForCardNumber()).Returns("45123456789739852");

            //Act & Assert
            Assert.ThrowsException<InvalidCardNumberException>(() => cardPayment.Run(2.4f));
        }
    }
}
