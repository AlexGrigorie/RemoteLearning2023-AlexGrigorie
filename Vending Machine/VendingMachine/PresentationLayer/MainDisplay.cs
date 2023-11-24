using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class MainDisplay : DisplayBase
    {
        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (IUseCase useCase in useCases)
                DisplayUseCase(useCase);

            while (true)
            {
                string rawValue = ReadCommandName();
                IUseCase selectedUseCase = useCases.FirstOrDefault(x => x.Name == rawValue);

                if (selectedUseCase == null)
                {
                    DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
                    continue;
                }

                return selectedUseCase;
            }
        }

        private static void DisplayUseCase(IUseCase useCase)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(useCase.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + useCase.Description);
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }

        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}