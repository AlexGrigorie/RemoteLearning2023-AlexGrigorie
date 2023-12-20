using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Helper;
using iQuest.VendingMachine.Interfaces;
using System;
namespace iQuest.VendingMachine.PaymentTypes
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
            if (string.IsNullOrEmpty(inputUser))
            {
                throw new CancelException();
            }
            else if (CardManager.CardValidator(inputUser))
            {
                cardPaymentTerminal.ThanksForThePayment();
            }
            else
            {
                throw new InvalidCardNumberException();
            }
        }

    }
}
