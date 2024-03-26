using Moq;
using VendingMachine.Presentation.Commands;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class BuyCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private BuyCommand buyCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            buyCommand = new BuyCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingBuyCommand__DisplayCorrectName()
        {
            string name = buyCommand.Name;
            Assert.AreEqual("buy", name);
        }
        [TestMethod]
        public void HavingBuyCommand__DisplayCorrectDescription()
        {
            string description = buyCommand.Description;
            Assert.AreEqual("Buy your favourite product", description);
        }
        [TestMethod]
        public void HavingBuyCommand_WhenNoAdminIsLogin_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = buyCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingBuyCommand_WhenAdminIsLogin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = buyCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
    }
}
