using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests
{
    [TestClass]
    public class LogoutUseCaseTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private LogoutUseCase logoutUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            logoutUseCase = new LogoutUseCase(mockAuthenticationService.Object);
        }
        [TestMethod]
        public void HavingLogoutUseCase__DisplayCorrectName()
        {
            string name = logoutUseCase.Name;
            Assert.AreEqual("logout", name);
        }
        [TestMethod]
        public void HavingLogoutUseCase__DisplayCorrectDescription()
        {
            string description = logoutUseCase.Description;
            Assert.AreEqual("Restrict access to administration buttons.", description);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenNoAdmin_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.UserIsLoggedIn).Returns(false);
            bool canExecute = logoutUseCase.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.UserIsLoggedIn).Returns(true);
            bool canExecute = logoutUseCase.CanExecute;
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenExecute_ThenSetUserIsLoggedInToFalse()
        {
            logoutUseCase.Execute();
            bool isLougout = mockAuthenticationService.Object.UserIsLoggedIn;
            Assert.IsFalse(isLougout);
        }
    }
}
