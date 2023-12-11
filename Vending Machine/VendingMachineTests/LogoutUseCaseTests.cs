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
            var vendingMachine = new Mock<IVendingMachineApplication>();
            LogoutUseCase logout = new LogoutUseCase(vendingMachine.Object);

            //Act
            logout.Execute();

            //Assert
            bool isLougout = vendingMachine.Object.UserIsLoggedIn;

            Assert.IsFalse(isLougout);
        }
    }
}
