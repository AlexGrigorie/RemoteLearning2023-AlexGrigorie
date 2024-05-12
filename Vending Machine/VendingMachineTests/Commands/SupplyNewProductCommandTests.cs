using Moq;
using VendingMachine.Business.Interfaces;
using VendingMachine.Presentation.Commands;

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class SupplyNewProductCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private SupplyNewProductCommand supplyNewProductCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            supplyNewProductCommand = new SupplyNewProductCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingSupplyNewProductCommand__DisplayCorrectName()
        {
            string name = supplyNewProductCommand.Name;
            Assert.AreEqual("addNewProduct", name);
        }
        [TestMethod]
        public void HavingSupplyNewProductCommand__DisplayCorrectDescription()
        {
            string description = supplyNewProductCommand.Description;
            Assert.AreEqual("Add or replace a product.", description);
        }
        [TestMethod]
        public void HavingSupplyNewProductCommand_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = supplyNewProductCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingSupplyNewProductCommand_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = supplyNewProductCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
