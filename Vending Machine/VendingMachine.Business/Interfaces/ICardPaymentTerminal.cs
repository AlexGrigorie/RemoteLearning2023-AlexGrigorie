namespace VendingMachine.Business.Interfaces
{
    internal interface ICardPaymentTerminal
    {
        public string AskForCardNumber();
        public void ThanksForThePayment();
    }
}
