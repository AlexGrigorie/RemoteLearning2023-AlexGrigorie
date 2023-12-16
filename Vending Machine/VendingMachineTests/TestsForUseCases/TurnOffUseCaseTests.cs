using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class TurnOffUseCaseTests
    {
        [TestMethod]
        public void HavingTurnOffUseCase_WhenName_DisplayCorrectValue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(mockVendingMachine.Object);

            //Act
            string name = turnOffUseCase.Name;

            //Assert
            Assert.AreEqual("exit", name);
        }
        [TestMethod]
        public void HavingTurnOffUseCase_WhenDescription_DisplayCorrectValue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(mockVendingMachine.Object);

            //Act
            string description = turnOffUseCase.Description;

            //Assert
            Assert.AreEqual("Go to live your life.", description);
        }
        [TestMethod]
        public void HavingTurnOffUseCase_WhenNoAdmin_CanExecuteIsFalse()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(mockVendingMachine.Object);
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, false);

            //Act
            bool canExecute = turnOffUseCase.CanExecute;

            //Assert
            Assert.IsFalse(canExecute);
        }
        [TestMethod]
        public void HavingTurnOffUseCase_WhenAdminIsLoggedIn_CanExecuteIsTrue()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(mockVendingMachine.Object);
            mockVendingMachine.SetupProperty(m => m.UserIsLoggedIn, true);

            //Act
            bool canExecute = turnOffUseCase.CanExecute;

            //Assert
            Assert.IsTrue(canExecute);
        }
        [TestMethod]
        public void HavingTurnOffUseCase_WhenExecute_ThenStopApplication()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            TurnOffUseCase turnOffUseCase = new TurnOffUseCase(mockVendingMachine.Object);

            //Act
            turnOffUseCase.Execute();

            //Assert
            mockVendingMachine.Verify(v => v.TurnOff(), Times.Once);
        }
    }
}
