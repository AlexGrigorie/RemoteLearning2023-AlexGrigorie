namespace iQuest.VendingMachine.Interfaces
{
    internal interface IMainDisplay
    {
        public string AskForPassword();
        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        public void DisplayExceptionMessage(Exception ex);
    }
}
