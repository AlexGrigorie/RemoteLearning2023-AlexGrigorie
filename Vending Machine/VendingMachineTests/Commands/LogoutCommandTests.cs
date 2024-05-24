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
    public class LogoutCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private LogoutCommand logoutCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            logoutCommand = new LogoutCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }

        [TestMethod]
        public void HavingLogoutCommand__DisplayCorrectName()
        {
            string name = logoutCommand.Name;
            Assert.AreEqual("logout", name);
        }
        [TestMethod]
        public void HavingLogoutCommand__DisplayCorrectDescription()
        {
            string description = logoutCommand.Description;
            Assert.AreEqual("Restrict access to administration buttons.", description);
        }
        [TestMethod]
        public void HavingLogoutCommand_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = logoutCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingLogoutCommand_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = logoutCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
