using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests
{
    [TestClass]
    public class LoginUseCaseTests
    {
        [TestMethod]
        public void HavingLogoutUseCase_WhenExecuteForCorrectPassword_ThenSetUserIsLoggedInToTrue()
        {
            //Arrange
            string password = "supercalifragilisticexpialidocious";
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            LoginUseCase login = new LoginUseCase(mockVendingMachine.Object, mockMainDisplay.Object);

            mockMainDisplay.Setup(m => m.AskForPassword()).Returns(password);
            mockVendingMachine.Setup(x => x.UserIsLoggedIn).Returns(true);

            //Act
            login.Execute();

            //Assert
            Assert.IsTrue(mockVendingMachine.Object.UserIsLoggedIn);

        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenExecuteForIncorrectPassword_ThenThrowInvalidPasswordException()
        {
            //Arrange
            string password = "supercalifragilisticexpialidocious_test";
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            LoginUseCase login = new LoginUseCase(mockVendingMachine.Object, mockMainDisplay.Object);

            mockMainDisplay.Setup(m => m.AskForPassword()).Returns(password);
            mockVendingMachine.Setup(x => x.UserIsLoggedIn).Returns(false);

            //Act & Assert
            Assert.ThrowsException<InvalidPasswordException>(() => login.Execute());
        }
    }
}
