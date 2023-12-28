using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
    {
        private const string askForMoney = 
            "Please insert the necessary amount!\nThe only accepted money is: 50bani, 1leu, 5lei, 10lei, 50lei\n";
        private static float addedMoney = 0;
        public float AskForMoney()
        {
            Display(askForMoney, ConsoleColor.Cyan);
            string userInput = Console.ReadLine();
            if(string.IsNullOrEmpty(userInput))
            {
                if(addedMoney == 0)
                {
                    throw new CancelException();
                }
                GiveBackChange(addedMoney);
                throw new CancelException();
            }
            float.TryParse(userInput, out float amount);
            addedMoney += amount;
            return amount;
        }

        public void GiveBackChange(float change) 
        {
            Display($"This is your change:{change}lei\n", color: ConsoleColor.Cyan);
        }
    }
}
