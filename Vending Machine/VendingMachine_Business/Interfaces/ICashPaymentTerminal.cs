namespace VendingMachine_Business.Interfaces
{
    internal interface ICashPaymentTerminal
    {
        public float AskForMoney();
        public void GiveBackChange(float change);
    }
}
