using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests
{
    [TestClass]
    public class LogoutUseCaseTests
    {
        [TestMethod]
        public void HavingLogoutUseCase_WhenExecute_ThenSetUserIsLoggedInToFalse()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            LogoutUseCase logout = new LogoutUseCase(mockVendingMachine.Object);

            //Act
            logout.Execute();

            //Assert
            bool isLougout = mockVendingMachine.Object.UserIsLoggedIn;

            Assert.IsFalse(isLougout);
        }
    }
}
