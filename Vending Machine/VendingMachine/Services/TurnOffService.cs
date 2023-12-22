using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.Services
{
    internal class TurnOffService : ITurnOffService
    {
        public bool TurnOffWasRequested { get; private set; } = false;
        public void TurnOff()
        {
            TurnOffWasRequested = true;
        }
    }
}
