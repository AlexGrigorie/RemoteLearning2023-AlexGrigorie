namespace VendingMachine.Business.Interfaces
{
    internal interface IApplicationCommand
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute();
    }
}
