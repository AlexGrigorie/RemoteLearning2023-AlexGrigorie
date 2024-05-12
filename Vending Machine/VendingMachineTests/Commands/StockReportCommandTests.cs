using Moq;
using VendingMachine.Business.Interfaces;
using VendingMachine.Presentation.Commands;

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class StockReportCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private StockReportCommand stockReportCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            stockReportCommand = new StockReportCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingStockReportCommand__DisplayCorrectName()
        {
            string name = stockReportCommand.Name;
            Assert.AreEqual("stock", name);
        }
        [TestMethod]
        public void HavingStockReportCommand__DisplayCorrectDescription()
        {
            string description = stockReportCommand.Description;
            Assert.AreEqual("Generate the stock of products.", description);
        }
        [TestMethod]
        public void HavingStockReportCommand_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = stockReportCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingStockReportCommand_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = stockReportCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
