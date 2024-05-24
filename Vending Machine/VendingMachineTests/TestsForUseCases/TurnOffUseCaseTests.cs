using Moq;
<<<<<<< HEAD
using VendingMachine_Business.Interfaces;
=======
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.UseCase;
>>>>>>> main

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
<<<<<<< HEAD
            mockLoggerService = new Mock<ILoggerService>();
            turnOffUseCase = new TurnOffUseCase(mockTurnOffService.Object, mockLoggerService.Object);
=======
            turnOffUseCase = new TurnOffUseCase(mockTurnOffService.Object);
>>>>>>> main
        }
        [TestMethod]
        public void TurnOffUseCase_Execute_CallsTurnOffMethodOnTurnOffService()
        {
            turnOffUseCase.Execute();
            mockTurnOffService.Verify(x => x.TurnOff(), Times.Once);
        }
    }
}
