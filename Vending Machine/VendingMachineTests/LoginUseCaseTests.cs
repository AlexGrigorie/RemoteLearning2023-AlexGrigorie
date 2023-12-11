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
            var vendingMachine = new Mock<IVendingMachineApplication>();
            var mainDisplay = new Mock<IMainDisplay>();
            LoginUseCase login = new LoginUseCase(vendingMachine.Object, mainDisplay.Object);

            mainDisplay.Setup(m => m.AskForPassword()).Returns(password);
            vendingMachine.Setup(x => x.UserIsLoggedIn).Returns(true);

            //Act
            login.Execute();

            //Assert
            Assert.IsTrue(vendingMachine.Object.UserIsLoggedIn);

        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenExecuteForIncorrectPassword_ThenThrowInvalidPasswordException()
        {
            //Arrange
            string password = "supercalifragilisticexpialidocious_test";
            var vendingMachine = new Mock<IVendingMachineApplication>();
            var mainDisplay = new Mock<IMainDisplay>();
            LoginUseCase login = new LoginUseCase(vendingMachine.Object, mainDisplay.Object);

            mainDisplay.Setup(m => m.AskForPassword()).Returns(password);
            vendingMachine.Setup(x => x.UserIsLoggedIn).Returns(false);

            //Act & Assert
            Assert.ThrowsException<InvalidPasswordException>(() => login.Execute());
        }
    }
}
