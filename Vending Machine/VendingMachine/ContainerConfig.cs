using Autofac;
using iQuest.VendingMachine.PresentationLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using VendingMachine.Business;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Reports.Sales;
using VendingMachine.Business.Serialization;
using VendingMachine.Business.Services;
using VendingMachine.Business.UseCase;
using VendingMachine.DataAccess.InMemory;
using VendingMachine.DataAccess.SqlServer;
using VendingMachine.Presentation.Commands;
using VendingMachine.Presentation.PresentationLayer;

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
            builder.RegisterType<StockReportCommand>().As<IApplicationCommand>();
            builder.RegisterType<SalesReportCommand>().As<IApplicationCommand>();
            builder.RegisterType<VolumeReportCommand>().As<IApplicationCommand>();
            builder.RegisterType<SupplyExistingProductCommand>().As<IApplicationCommand>();
            builder.RegisterType<SupplyNewProductCommand>().As<IApplicationCommand>();
            builder.RegisterType<TurnOffCommand>().As<IApplicationCommand>();
            builder.RegisterType<ReportsView>().As<IReportsView>();
            builder.RegisterType<SupplyProductView>().As<ISupplyProducView>();
            builder.RegisterType<SalesRepository>().As<ISalesRepository>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>().SingleInstance();
            builder.RegisterType<TurnOffService>().As<ITurnOffService>().SingleInstance();

            var reportType = GetReportType();
            var reportPath = GetReportPath();

            switch (reportType)
            {
                case ".xml":
                    builder.Register(s => new ReportXmlSerialization(reportPath, reportType)).As<IFileSerialization>().SingleInstance();
                    break;
                default:
                    builder.Register(s => new ReportJsonSerialization(reportPath, reportType)).As<IFileSerialization>().SingleInstance();
                    builder.RegisterType<TurnOffCommand>().As<IApplicationCommand>();
                    builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
                    builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>().SingleInstance();
                    builder.RegisterType<TurnOffService>().As<ITurnOffService>().SingleInstance();
                    break;
            }

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

        private static string GetReportPath()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            return configuration["AppSettings:PathForReport"];
        }
        private static string GetReportType()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            return configuration["AppSettings:ReportsType"];
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
