using Autofac;
using VendingMachine.Business.Interfaces;

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