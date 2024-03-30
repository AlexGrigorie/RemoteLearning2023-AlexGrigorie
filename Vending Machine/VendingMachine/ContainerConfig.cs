using Autofac;
using iQuest.VendingMachine.PresentationLayer;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Linq;
using System.Reflection;
using VendingMachine.DataAccess.InMemory;
using VendingMachine.Presentation.Commands;
using VendingMachine.Presentation.PresentationLayer;
using VendingMachine_Business.Interfaces;
using VendingMachine_Business.Reports.Sales;
using VendingMachine_Business.Serialization;
using VendingMachine_Business.Services;

namespace iQuest.VendingMachine
{
    internal static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(VendingMachine_Business)))
                   .Where(t => t.GetInterfaces().Contains(typeof(IUseCase)))
                   .AsSelf();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(VendingMachine_Business)))
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

            //builder.RegisterType<DatabaseProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<InMemoryProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>().SingleInstance();
            builder.RegisterType<TurnOffService>().As<ITurnOffService>().SingleInstance();
            builder.RegisterType<LoggerService>().As<ILoggerService>().SingleInstance();

            var reportType = GetReportType();
            var reportPath = GetReportPath();

            switch (reportType)
            {
                case ".xml":
                    builder.Register(s => new ReportXmlSerialization(reportPath, reportType)).As<IFileSerialization>().SingleInstance();
                    break;
                default:
                    builder.Register(s => new ReportJsonSerialization(reportPath, reportType)).As<IFileSerialization>().SingleInstance();
                    break;
            }

            return builder.Build();
        }

        private static string GetReportType()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            return configuration["AppSettings:RaportsType"];
        }

        private static string GetReportPath()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            return configuration["AppSettings:PathForReport"];
        }

    }
}
