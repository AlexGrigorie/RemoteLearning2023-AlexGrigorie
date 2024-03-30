using Moq;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachineTests.TestsForUseCases
{
    [TestClass]
    public class TurnOffUseCaseTests
    {
        private Mock<ITurnOffService> mockTurnOffService;
        private Mock<ILoggerService> mockLoggerService;
        private TurnOffUseCase turnOffUseCase;

        [TestInitialize]
        public void SetupTest()
        {
            mockTurnOffService = new Mock<ITurnOffService>();
            mockLoggerService = new Mock<ILoggerService>();
            turnOffUseCase = new TurnOffUseCase(mockTurnOffService.Object, mockLoggerService.Object);
        }
        [TestMethod]
        public void TurnOffUseCase_Execute_CallsTurnOffMethodOnTurnOffService()
        {
            turnOffUseCase.Execute();
            mockTurnOffService.Verify(x => x.TurnOff(), Times.Once);
        }
    }
}
