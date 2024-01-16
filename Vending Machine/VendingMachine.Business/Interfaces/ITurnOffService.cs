namespace iQuest.VendingMachine.Interfaces
{
    internal interface ITurnOffService
    {
        public bool WasTurnOffRequested { get; }
        public void TurnOff();
    }
}
