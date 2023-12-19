using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests
{
    [TestClass]
    public class LogoutUseCaseTests
    {
        private Mock<IVendingMachineApplication> mockVendingMachine;
        private LogoutUseCase logoutUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockVendingMachine = new Mock<IVendingMachineApplication>();
            logoutUseCase = new LogoutUseCase(mockVendingMachine.Object);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenName_DisplayCorrectValue()
        {
            //Act
            string name = logoutUseCase.Name;

            //Assert
            Assert.AreEqual("logout", name);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenDescription_DisplayCorrectValue()
        {
            //Act
            string description = logoutUseCase.Description;

            //Assert
            Assert.AreEqual("Restrict access to administration buttons.", description);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenNoAdmin_CanExecuteIsFalse()
        {
            //Arrange
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
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, true);

            //Act
            bool canExecute = logoutUseCase.CanExecute;

            //Assert
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingLogoutUseCase_WhenExecute_ThenSetUserIsLoggedInToFalse()
        {
            //Act
            logoutUseCase.Execute();

            //Assert
            bool isLougout = mockVendingMachine.Object.UserIsLoggedIn;

            Assert.IsFalse(isLougout);
        }
    }
}
