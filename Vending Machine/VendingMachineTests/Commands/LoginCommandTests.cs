using Moq;
using VendingMachine.Presentation.Commands;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class LoginCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private LoginCommand loginCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            loginCommand = new LoginCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingLoginCommand__DisplayCorrectName()
        {
            string name = loginCommand.Name;
            Assert.AreEqual("login", name);
        }
        [TestMethod]
        public void HavingLoginCommand__DisplayCorrectDescription()
        {
            string name = loginCommand.Description;
            Assert.AreEqual("Get access to administration buttons.", name);
        }
        [TestMethod]
        public void HavingLoginCommand_WhenNoAdmin_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = loginCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingCommand_WhenAdminIsLoggedIn_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = loginCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
    }
}
