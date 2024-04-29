using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class TurnOffUseCaseTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<ITurnOffService> mockTurnOffService;
        private TurnOffUseCase turnOffUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockTurnOffService = new Mock<ITurnOffService>();
            turnOffUseCase = new TurnOffUseCase(mockAuthenticationService.Object, mockTurnOffService.Object);
        }
        [TestMethod]
        public void HavingTurnOffUseCase__DisplayCorrectName()
        {
            string name = turnOffUseCase.Name;
            Assert.AreEqual("exit", name);
        }
        [TestMethod]
        public void HavingTurnOffUseCase__DisplayCorrectDescription()
        {
            string description = turnOffUseCase.Description;
            Assert.AreEqual("Go to live your life.", description);
        }
        [TestMethod]
        public void HavingTurnOffUseCase_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = turnOffUseCase.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingTurnOffUseCase_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = turnOffUseCase.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
