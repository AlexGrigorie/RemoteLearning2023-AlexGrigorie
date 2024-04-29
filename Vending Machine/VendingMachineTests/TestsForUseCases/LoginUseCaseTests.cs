using Moq;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCase;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class LoginUseCaseTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IMainDisplay> mockMainDisplay;
        private LoginUseCase loginUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockMainDisplay = new Mock<IMainDisplay>();
            loginUseCase = new LoginUseCase(mockAuthenticationService.Object, mockMainDisplay.Object);
        }
        [TestMethod]
        public void HavingLoginUseCase__DisplayCorrectName()
        {
            string name = loginUseCase.Name;
            Assert.AreEqual("login", name);
        }
        [TestMethod]
        public void HavingLoginUseCase__DisplayCorrectDescription()
        {
            string name = loginUseCase.Description;
            Assert.AreEqual("Get access to administration buttons.", name);
        }
        [TestMethod]
        public void HavingLoginUseCase_WhenNoAdmin_CanExecuteIsTrue()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(false);
            bool canExecute = loginUseCase.CanExecute;
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingLoginUseCase_WhenAdminIsLoggedIn_CanExecuteIsFalse()
        {
            mockAuthenticationService.Setup(m => m.IsUserLoggedIn).Returns(true);
            bool canExecute = loginUseCase.CanExecute;
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingLoginUseCase_WhenExecuteForCorrectPassword_ThenSetUserIsLoggedInToTrue()
        {
            string password = "supercalifragilisticexpialidocious";
            mockMainDisplay.Setup(m => m.AskForPassword()).Returns(password);
            mockAuthenticationService.Setup(x => x.IsUserLoggedIn).Returns(true);
            loginUseCase.Execute();
            Assert.IsTrue(mockAuthenticationService.Object.IsUserLoggedIn);
        }
    }
}
