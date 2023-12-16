using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
    {
        private const string askForMoney = 
            "Please insert the necessary amount!\nThe only accepted money is: 50bani, 1leu, 5lei, 10lei, 50lei\n";
        public float AskForMoney()
        {
            Display(askForMoney, ConsoleColor.Cyan);
            float.TryParse(Console.ReadLine(), out float amount);
            return amount;
        }

        public void GiveBackChange(float change) 
        {
            Display($"This is your change:{change}lei\n", color: ConsoleColor.Cyan);
        }
    }
}
