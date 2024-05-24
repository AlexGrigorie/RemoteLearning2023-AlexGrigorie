using Moq;
<<<<<<< HEAD
using VendingMachine_Business.Interfaces;
=======
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCase;
>>>>>>> main

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class LoginUseCaseTests
    {
        private Mock<IAuthenticationService> mockAuthenticationService;
        private Mock<IMainDisplay> mockMainDisplay;
        private Mock<ILoggerService> mockLoggerService;
        private LoginUseCase loginUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockAuthenticationService = new Mock<IAuthenticationService>();
            mockMainDisplay = new Mock<IMainDisplay>();
<<<<<<< HEAD
            mockLoggerService = new Mock<ILoggerService>();
            loginUseCase = new LoginUseCase(mockAuthenticationService.Object, mockMainDisplay.Object, mockLoggerService.Object);
=======
            loginUseCase = new LoginUseCase(mockAuthenticationService.Object, mockMainDisplay.Object);
>>>>>>> main
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
