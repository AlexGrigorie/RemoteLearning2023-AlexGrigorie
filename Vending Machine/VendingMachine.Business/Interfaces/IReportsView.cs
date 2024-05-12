namespace VendingMachine.Business.Interfaces
{
    internal interface IReportsView
    {
        DateTime AskForStartDate();
        DateTime AskForEndDate();
        void AskForTimeInterval();
        void DisplaySuccessMessage();
        string DisplayCurrentDateTime();
    }
}
