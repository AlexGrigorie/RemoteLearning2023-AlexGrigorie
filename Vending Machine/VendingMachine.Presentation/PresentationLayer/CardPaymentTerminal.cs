using VendingMachine_Business;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase, ICardPaymentTerminal
    {
        private const string askForMoney ="Please insert your card number: ";
        public string AskForCardNumber()
        {
            Display(askForMoney, ConsoleColor.Cyan);
            string cardNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(cardNumber))
            {
                throw new CancelException();
            }
            return cardNumber;
        }

        public void ThanksForThePayment()
        {
            Console.WriteLine("Thank you for your payment!\n");
        }
    }
}
