namespace VendingMachine.Business.Interfaces
{
    internal interface IReportsView
    {
       public DateTime AskForStartDate();
       public DateTime AskForEndDate();
       public void AskForTimeInterval();
       public void DisplaySuccessMessage();
       public string DisplayCurrentDateTime();
    }
}
