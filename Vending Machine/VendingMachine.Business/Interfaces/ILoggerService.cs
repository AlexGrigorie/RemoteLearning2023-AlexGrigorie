namespace VendingMachine.Business.Interfaces
{
    internal interface ILoggerService
    {
        void LogError(Exception ex);
        void LogInformation(string message);
    }
}
