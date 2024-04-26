using VendingMachine_Business;
using VendingMachine_Business.Interfaces;


namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
    {
        private const string askForMoney = 
            "Please insert the necessary amount!\nThe only accepted money is: 50bani, 1leu, 5lei, 10lei, 50lei\n";

        public float AskForMoney()
        {
            Display(askForMoney, ConsoleColor.Cyan);
            string userInput = Console.ReadLine();
            if(string.IsNullOrEmpty(userInput))
            {
                throw new CancelException();
            }

            if(!float.TryParse(userInput, out float amount))
            {
                throw new InvalidMoneyException();
            }

            return amount;
        }

        public void GiveBackChange(float change) 
        {
            Display($"This is your change:{change}lei\n", color: ConsoleColor.Cyan);
        }
    }
}
