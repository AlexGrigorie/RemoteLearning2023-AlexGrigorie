using Moq;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.TestsForUseCases
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
        public void HavingLogoutUseCase_WhenExecute_ThenSetUserIsLoggedInToFalse()
        {
            logoutUseCase.Execute();
            bool isLougout = mockAuthenticationService.Object.IsUserLoggedIn;
            Assert.IsFalse(isLougout);
        }
    }
}
