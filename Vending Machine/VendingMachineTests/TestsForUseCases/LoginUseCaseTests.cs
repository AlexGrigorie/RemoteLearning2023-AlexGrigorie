using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class LoginUseCaseTests
    {
        [TestMethod]
        public void HavingLoginUseCase_WhenName_DisplayCorrectValue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            LoginUseCase loginUseCase = new LoginUseCase(mockVendingMachine.Object, mockMainDisplay.Object);

            //Act
            string name = loginUseCase.Name;

            //Assert
            Assert.AreEqual("login", name);
        }
        [TestMethod]
        public void HavingLoginUseCase_WhenDescription_DisplayCorrectValue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            LoginUseCase loginUseCase = new LoginUseCase(mockVendingMachine.Object, mockMainDisplay.Object);

            //Act
            string name = loginUseCase.Description;

            //Assert
            Assert.AreEqual("Get access to administration buttons.", name);
        }
        [TestMethod]
        public void HavingLoginUseCase_WhenNoAdmin_CanExecuteIsTrue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            LoginUseCase loginUseCase = new LoginUseCase(mockVendingMachine.Object, mockMainDisplay.Object);
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, false);

            //Act
            bool canExecute = loginUseCase.CanExecute;

            //Assert
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingLoginUseCase_WhenAdminIsLoggedIn_CanExecuteIsFalse()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            LoginUseCase loginUseCase = new LoginUseCase(mockVendingMachine.Object, mockMainDisplay.Object);
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, true);

            //Act
            bool canExecute = loginUseCase.CanExecute;

            //Assert
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingLoginUseCase_WhenExecuteForCorrectPassword_ThenSetUserIsLoggedInToTrue()
        {
            //Arrange
            string password = "supercalifragilisticexpialidocious";
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            LoginUseCase loginUseCase = new LoginUseCase(mockVendingMachine.Object, mockMainDisplay.Object);

            mockMainDisplay.Setup(m => m.AskForPassword()).Returns(password);
            mockVendingMachine.Setup(x => x.UserIsLoggedIn).Returns(true);

            //Act
            loginUseCase.Execute();

            //Assert
            Assert.IsTrue(mockVendingMachine.Object.UserIsLoggedIn);

        }
        [TestMethod]
        public void HavingLoginUseCase_WhenExecuteForIncorrectPassword_ThenThrowInvalidPasswordException()
        {
            //Arrange
            string password = "supercalifragilisticexpialidocious_test";
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            var mockMainDisplay = new Mock<IMainDisplay>();
            LoginUseCase loginUseCase = new LoginUseCase(mockVendingMachine.Object, mockMainDisplay.Object);

            mockMainDisplay.Setup(m => m.AskForPassword()).Returns(password);
            mockVendingMachine.Setup(x => x.UserIsLoggedIn).Returns(false);

            //Act & Assert
            Assert.ThrowsException<InvalidPasswordException>(() => loginUseCase.Execute());
        }
    }
}
