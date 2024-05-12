using iQuest.VendingMachine.PresentationLayer;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Presentation.PresentationLayer
{
    internal class ReportsView : DisplayBase, IReportsView
    {
        public void AskForTimeInterval()
        {
            Display("You need to enter the start date and end date in the following format (yyyy/MM/dd/HH/mm/ss)\n", color: ConsoleColor.Cyan);
        }

        public void DisplaySuccessMessage()
        {
            Display("Your report was created with successful!", color: ConsoleColor.Green);
        }

        public DateTime AskForStartDate()
        {
            Display("\nStart date:", color: ConsoleColor.Cyan);
            string startDateReader = Console.ReadLine();
            DateTime startDate = Convert.ToDateTime(GetDate(startDateReader));
            return startDate;
        }

        public DateTime AskForEndDate()
        {
            Display("\nEnd date:", color: ConsoleColor.Cyan);
            string endDateReader = Console.ReadLine();
            DateTime endDate = Convert.ToDateTime(GetDate(endDateReader));

            return endDate;
        }
        public string DisplayCurrentDateTime()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.ToString("yyyy MM dd HHmmss");
        }

        private bool IsValidDate(string date)
        {
            var formats = new[] { "yyyy/MM/dd/HH/mm/ss", "yyyy/MM/dd", "yyyy/MM" };
            return DateTime.TryParseExact(date, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        }
        private string GetDate(string dateReader)
        {
            if (!IsValidDate(dateReader))
            {
                do
                {
                    Display("Format date incorrect!!!\nTry Again!(This is the correct format yyyy/MM/dd/HH/mm/ss)", color: ConsoleColor.Red);
                    Display("\nStart date:", color: ConsoleColor.Cyan);
                    dateReader = Console.ReadLine();
                } while (!IsValidDate(dateReader));
            }

            return dateReader;
        }

    }
}
