using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace iQuest.VendingMachine.Interfaces
{

    internal interface IVendingMachineApplication
    {
        public void Run();
        public void TurnOff();
        public bool UserIsLoggedIn { get; set; }
    }
}
