using Autofac;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            var vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Resolve<IVendingMachineApplication>().Run();
        }

        private static IContainer BuildApplication()
        {
            return ContainerConfig.Configure();
        }
    }
}