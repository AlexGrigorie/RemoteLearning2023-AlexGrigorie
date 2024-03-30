using Moq;
using VendingMachine.Presentation.Commands;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class VolumeReportCommandTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private VolumeReportCommand volumeReportCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            volumeReportCommand = new VolumeReportCommand(mockAuthenticationService.Object, mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingVolumeReportCommand__DisplayCorrectName()
        {
            string name = volumeReportCommand.Name;
            Assert.AreEqual("volume", name);
        }
        [TestMethod]
        public void HavingVolumeReportCommand__DisplayCorrectDescription()
        {
            string description = volumeReportCommand.Description;
            Assert.AreEqual("Generate report to see all quantity of products which were sold.", description);
        }
        [TestMethod]
        public void HavingVolumeReportCommand_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = volumeReportCommand.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingVolumeReportCommand_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = volumeReportCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
