namespace VendingMachine_Business.Interfaces
{
    internal interface ICardPaymentTerminal
    {
        public string AskForCardNumber();
        public void ThanksForThePayment();
    }
}
