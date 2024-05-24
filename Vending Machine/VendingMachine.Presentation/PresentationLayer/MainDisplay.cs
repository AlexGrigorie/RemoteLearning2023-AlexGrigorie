using VendingMachine.Business.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class MainDisplay : DisplayBase, IMainDisplay
    {
        public IApplicationCommand ChooseCommand(IEnumerable<IApplicationCommand> useCases)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (IApplicationCommand useCase in useCases)
                DisplayUseCase(useCase);

            while (true)
            {
                string rawValue = ReadCommandName();
                IApplicationCommand selectedUseCase = useCases.FirstOrDefault(x => x.Name == rawValue);

                if (selectedUseCase == null)
                {
                    DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
                    continue;
                }

                return selectedUseCase;
            }
        }

        private static void DisplayUseCase(IApplicationCommand useCase)
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
        public void DisplayExceptionMessage(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}