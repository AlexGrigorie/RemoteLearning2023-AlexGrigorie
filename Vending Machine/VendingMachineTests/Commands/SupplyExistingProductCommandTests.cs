using Moq;
using VendingMachine.Presentation.Commands;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class SupplyExistingProductCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private SupplyExistingProductCommand supplyExistingProductCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            supplyExistingProductCommand = new SupplyExistingProductCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingSupplyExistingProductCommand__DisplayCorrectName()
        {
            string name = supplyExistingProductCommand.Name;
            Assert.AreEqual("increaseQuantity", name);
        }
        [TestMethod]
        public void HavingSupplyExistingProductCommand__DisplayCorrectDescription()
        {
            string description = supplyExistingProductCommand.Description;
            Assert.AreEqual("Increase quantity for an existing product.", description);
        }
        [TestMethod]
        public void HavingSupplyExistingProductCommand_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = supplyExistingProductCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingSupplyExistingProductCommand_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = supplyExistingProductCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
