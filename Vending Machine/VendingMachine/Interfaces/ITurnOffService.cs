namespace iQuest.VendingMachine.Interfaces
{
    internal interface ITurnOffService
    {
        public bool TurnOffWasRequested { get; }
        public void TurnOff();
    }
}
