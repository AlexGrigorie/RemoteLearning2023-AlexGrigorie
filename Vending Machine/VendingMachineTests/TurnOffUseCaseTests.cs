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
            var vendingMachine = new Mock<IVendingMachineApplication>();
            TurnOffUseCase turnOff = new TurnOffUseCase(vendingMachine.Object);

            //Act
            turnOff.Execute();

            //Assert
            vendingMachine.Verify(v => v.TurnOff(), Times.Once);
        }
    }
}
