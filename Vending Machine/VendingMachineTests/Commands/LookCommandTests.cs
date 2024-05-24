using Moq;
<<<<<<< HEAD
using VendingMachine.Presentation.Commands;
using VendingMachine_Business.Interfaces;
=======
using VendingMachine.Business.Interfaces;
using VendingMachine.Presentation.Commands;
>>>>>>> main

namespace iQuest.VendingMachineTests.Commands
{
    [TestClass]
    public class LookCommandTests
    {
        private Mock<IUseCaseFactory> mockUseCaseFactory;
        private LookCommand lookCommand;

        [TestInitialize]
        public void SetupTest()
        {
            mockUseCaseFactory = new Mock<IUseCaseFactory>();
            lookCommand = new LookCommand(mockUseCaseFactory.Object);
        }
        [TestMethod]
        public void HavingLookCommand__DisplayCorrectName()
        {
            string name = lookCommand.Name;
            Assert.AreEqual("look", name);
        }
        [TestMethod]
        public void HavingLookCommand__DisplayCorrectDescription()
        {
            string description = lookCommand.Description;
            Assert.AreEqual("Display all available products.", description);
        }
        [TestMethod]
        public void HavingLookCommand_WhenAnyone_CanExecuteIsTrue()
        {
            bool canExecute = lookCommand.CanExecute;
            Assert.IsTrue(canExecute);
        }
    }
}
