using Moq;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCase;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class TurnOffUseCaseTests
    {
        private Mock<ITurnOffService> mockTurnOffService;
        private TurnOffUseCase turnOffUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockTurnOffService = new Mock<ITurnOffService>();
            turnOffUseCase = new TurnOffUseCase(mockTurnOffService.Object);
        }
        [TestMethod]
        public void TurnOffUseCase_Execute_CallsTurnOffMethodOnTurnOffService()
        {
            turnOffUseCase.Execute();
            mockTurnOffService.Verify(x => x.TurnOff(), Times.Once);
        }
    }
}
