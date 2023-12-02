using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class ExceptionHandler
    {
        public static void HandleException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
