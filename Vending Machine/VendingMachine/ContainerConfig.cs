using Autofac;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Linq;
using System.Reflection;
using VendingMachine.DataAccess.InMemory;
using VendingMachine_Business.Interfaces;

namespace iQuest.VendingMachine
{
    internal static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(VendingMachine_Business)))
                   .Where(t => t.GetInterfaces().Contains(typeof(IUseCase)))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(VendingMachine_Business)))
                   .Where(t => t.GetInterfaces().Contains(typeof(IPaymentAlgorithm)))
                   .AsImplementedInterfaces();

            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<MainDisplay>().As<IMainDisplay>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<CardPaymentTerminal>().As<ICardPaymentTerminal>();
            builder.RegisterType<CashPaymentTerminal>().As<ICashPaymentTerminal>();
            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();

            //builder.RegisterType<DatabaseProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<InMemoryProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>().SingleInstance();
            builder.RegisterType<TurnOffService>().As<ITurnOffService>().SingleInstance();

            return builder.Build();
        }
    }
}
