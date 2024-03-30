using Moq;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class LogoutUseCaseTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<ILoggerService> mockLoggerService;
        private LogoutUseCase logoutUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockLoggerService = new Mock<ILoggerService>();
            logoutUseCase = new LogoutUseCase(mockAuthenticationService.Object, mockLoggerService.Object);
        }

        [TestMethod]
        public void HavingLogoutUseCase_WhenExecute_ThenSetUserIsLoggedInToFalse()
        {
            logoutUseCase.Execute();
            bool isLougout = mockAuthenticationService.Object.IsUserLoggedIn;
            Assert.IsFalse(isLougout);
        }
    }
}
