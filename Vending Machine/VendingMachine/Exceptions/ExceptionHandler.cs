using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class ExceptionHandler
    {
        public static void HandleException(Exception ex)
        {

            if (ex is CancelException)
            {
                DisplayExptionMessage(ex);
            }
            else if (ex is InsufficientStockException)
            {
                DisplayExptionMessage(ex);
            }
            else if (ex is CancelException)
            {
                DisplayExptionMessage(ex);
            }
            else if (ex is InvalidPasswordException)
            {
                DisplayExptionMessage(ex);
            }
        }

        private static void DisplayExptionMessage(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
