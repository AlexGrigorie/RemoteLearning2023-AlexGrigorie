namespace VendingMachine_Business.Interfaces
{
    internal interface IMainDisplay
    {
        public string AskForPassword();
        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        public void DisplayExceptionMessage(Exception ex);
    }
}
