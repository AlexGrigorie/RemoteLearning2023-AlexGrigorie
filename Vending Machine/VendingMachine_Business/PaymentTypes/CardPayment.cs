namespace VendingMachine_Business.Interfaces
{
    internal class CardPayment : IPaymentAlgorithm
    {
        public string Name => "Card";
        private readonly ICardPaymentTerminal cardPaymentTerminal;

        public CardPayment(ICardPaymentTerminal cardPaymentTerminal)
        {
            this.cardPaymentTerminal = cardPaymentTerminal ?? throw new ArgumentNullException(nameof(cardPaymentTerminal));
        }
        public void Run(float price)
        {
            string inputUser = cardPaymentTerminal.AskForCardNumber();
            if (!CardManager.CardValidator(inputUser))
            {
                throw new InvalidCardNumberException();
            }
            cardPaymentTerminal.ThanksForThePayment();
        }

    }
}
