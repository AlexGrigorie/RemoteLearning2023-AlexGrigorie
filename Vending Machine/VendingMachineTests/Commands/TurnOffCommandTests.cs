using Moq;
using VendingMachine.Presentation.Commands;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class TurnOffCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private TurnOffCommand turnOffCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            turnOffCommand = new TurnOffCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingTurnOffCommand__DisplayCorrectName()
        {
            string name = turnOffCommand.Name;
            Assert.AreEqual("exit", name);
        }
        [TestMethod]
        public void HavingTurnOffCommand__DisplayCorrectDescription()
        {
            string description = turnOffCommand.Description;
            Assert.AreEqual("Go to live your life.", description);
        }
        [TestMethod]
        public void HavingTurnOffCommand_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = turnOffCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingTurnOffCommand_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = turnOffCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
