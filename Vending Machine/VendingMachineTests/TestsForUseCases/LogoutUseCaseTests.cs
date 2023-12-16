using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class LogoutUseCaseTests
    {
        [TestMethod]
        public void HavingLogoutUseCase_WhenName_DisplayCorrectValue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            LogoutUseCase logoutUseCase = new LogoutUseCase(mockVendingMachine.Object);

            //Act
            string name = logoutUseCase.Name;

            //Assert
            Assert.AreEqual("logout", name);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenDescription_DisplayCorrectValue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            LogoutUseCase logoutUseCase = new LogoutUseCase(mockVendingMachine.Object);

            //Act
            string description = logoutUseCase.Description;

            //Assert
            Assert.AreEqual("Restrict access to administration buttons.", description);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenNoAdmin_CanExecuteIsFalse()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            LogoutUseCase logoutUseCase = new LogoutUseCase(mockVendingMachine.Object);
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, false);

            //Act
            bool canExecute = logoutUseCase.CanExecute;

            //Assert
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            LogoutUseCase logoutUseCase = new LogoutUseCase(mockVendingMachine.Object);
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, true);

            //Act
            bool canExecute = logoutUseCase.CanExecute;

            //Assert
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenExecute_ThenSetUserIsLoggedInToFalse()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            LogoutUseCase logoutUseCase = new LogoutUseCase(mockVendingMachine.Object);

            //Act
            logoutUseCase.Execute();

            //Assert
            bool isLougout = mockVendingMachine.Object.UserIsLoggedIn;

            Assert.IsFalse(isLougout);
        }
    }
}
