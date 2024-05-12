using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.Services
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
