using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.PaymentTypes
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
