using iQuest.VendingMachine.Exceptions;
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
            if(IsCardNumberValid(cardPaymentTerminal.AskForCardNumber()))
            {
                Console.WriteLine("Thank you for your payment!\n");
            }
            else
            {
                throw new InvalidCardNumberException();
            }
        }
        private bool IsCardNumberValid(string cardNumber)
        {
            int totalSum = ToInt(cardNumber[cardNumber.Length - 1]);

            for (int i = cardNumber.Length - 2; i >= 0; i--)
            {
                int sum;
                int digit = ToInt(cardNumber[i]);

                if (i % 2 == 0)
                {
                    digit *= 2;
                }
                sum = digit / 10 + digit % 10;
                totalSum += sum;
            }

            return totalSum % 10 == 0;
        }
        private int ToInt(char c)
        {
            return c - '0';
        }
    }
}
