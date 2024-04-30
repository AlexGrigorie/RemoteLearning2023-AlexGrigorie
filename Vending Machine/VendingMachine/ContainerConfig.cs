using Autofac;
using iQuest.VendingMachine.PresentationLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using VendingMachine.Business;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Services;
using VendingMachine.Business.UseCase;
using VendingMachine.DataAccess.InMemory;
using VendingMachine.DataAccess.SqlServer;
using VendingMachine.Presentation.Commands;


namespace iQuest.VendingMachine
{
    internal static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            Assembly useCasesAssembly = typeof(IUseCase).Assembly;
            string projectName = Path.GetFileNameWithoutExtension(new Uri(useCasesAssembly.Location).LocalPath);
            builder.RegisterAssemblyTypes(Assembly.Load(projectName))
                   .Where(t => t.GetInterfaces().Contains(typeof(IUseCase)))
                   .AsSelf();

            builder.RegisterAssemblyTypes(Assembly.Load(projectName))
                   .Where(t => t.GetInterfaces().Contains(typeof(IPaymentAlgorithm)))
                   .AsImplementedInterfaces();

            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<MainDisplay>().As<IMainDisplay>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<CardPaymentTerminal>().As<ICardPaymentTerminal>();
            builder.RegisterType<CashPaymentTerminal>().As<ICashPaymentTerminal>();
            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();

            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();
            builder.RegisterType<BuyCommand>().As<IApplicationCommand>();
            builder.RegisterType<LookCommand>().As<IApplicationCommand>();
            builder.RegisterType<LoginCommand>().As<IApplicationCommand>();
            builder.RegisterType<LogoutCommand>().As<IApplicationCommand>();
            builder.RegisterType<TurnOffCommand>().As<IApplicationCommand>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>().SingleInstance();
            builder.RegisterType<TurnOffService>().As<ITurnOffService>().SingleInstance();

            var repType = GetRepoType();
            switch (repType)
            {
                case "InMemory":
                    builder.RegisterType<InMemoryProductRepository>().As<IProductRepository>().SingleInstance();
                    break;
                default:
                    builder.RegisterType<DatabaseProductRepository>().As<IProductRepository>().SingleInstance();
                    break;
            }

            return builder.Build();
        }
        private static string GetRepoType()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            return configuration["AppSettings:RepoType"];
        }
    }
}
