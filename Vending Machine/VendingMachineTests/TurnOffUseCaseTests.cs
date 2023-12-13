using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace iQuest.VendingMachineTests
{
    [TestClass]
    public class TurnOffUseCaseTests
    {
        [TestMethod]
        public void HavingTurnOffUseCase_WhenExecute_ThenStopApplication()
        {
            //Arrange
            var mockVendingMachine = new Mock<IVendingMachineApplication>();
            TurnOffUseCase turnOff = new TurnOffUseCase(mockVendingMachine.Object);

            //Act
            turnOff.Execute();

            //Assert
            mockVendingMachine.Verify(v => v.TurnOff(), Times.Once);
        }
    }
}
