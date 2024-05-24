using Moq;
<<<<<<< HEAD
using VendingMachine.Presentation.Commands;
using VendingMachine_Business.Interfaces;
=======
using VendingMachine.Business.Interfaces;
using VendingMachine.Presentation.Commands;
>>>>>>> main

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class SalesReportCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private SalesReportCommand salesReportCommand;
        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            salesReportCommand = new SalesReportCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingSalesReportCommand__DisplayCorrectName()
        {
            string name = salesReportCommand.Name;
            Assert.AreEqual("sales", name);
        }
        [TestMethod]
        public void HavingSalesReportCommand__DisplayCorrectDescription()
        {
            string description = salesReportCommand.Description;
            Assert.AreEqual("Generate the sales report for a specific period of time.", description);
        }
        [TestMethod]
        public void HavingSalesReportCommand_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = salesReportCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingSalesReportCommand_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = salesReportCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
