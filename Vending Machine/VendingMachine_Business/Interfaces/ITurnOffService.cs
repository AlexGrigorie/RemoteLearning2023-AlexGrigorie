namespace VendingMachine_Business.Interfaces
{
    internal interface ITurnOffService
    {
        public bool WasTurnOffRequested { get; }
        public void TurnOff();
    }
}
