namespace VendingMachine.Business.Interfaces
{
    internal interface IMainDisplay
    {
        public string AskForPassword();
        public IApplicationCommand ChooseCommand(IEnumerable<IApplicationCommand> useCases);
        public void DisplayExceptionMessage(Exception ex);
    }
}
