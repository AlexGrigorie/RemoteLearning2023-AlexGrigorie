using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.Services
{
    internal class TurnOffService : ITurnOffService
    {
        public bool WasTurnOffRequested { get; private set; } = false;
        public void TurnOff()
        {
            WasTurnOffRequested = true;
        }
    }
}
