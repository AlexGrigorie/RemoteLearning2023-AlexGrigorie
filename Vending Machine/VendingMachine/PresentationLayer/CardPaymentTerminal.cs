using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase, ICardPaymentTerminal
    {
        private const string askForMoney ="Please insert your card number: ";
        public string AskForCardNumber()
        {
            Display(askForMoney, ConsoleColor.Cyan);
            string cardNumber = Console.ReadLine();
            return cardNumber;
        }
    }
}
