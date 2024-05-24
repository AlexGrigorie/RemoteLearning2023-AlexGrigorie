using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Reports.Stock;

namespace VendingMachine.Business.UseCases
{
    internal class StockReportUseCase : IUseCase
    {
        private const string customMessageStockReport = "User has generated a stock report.";
        private readonly IFileSerialization fileSerialization;
        private readonly IProductRepository productRepository;
        private readonly IReportsView reportsView;
        private readonly ILoggerService loggerService;
        public StockReportUseCase(IFileSerialization fileSerialization, 
            IProductRepository productRepository, IReportsView reportsView, ILoggerService loggerService)
        {
            this.fileSerialization = fileSerialization ?? throw new ArgumentNullException(nameof(fileSerialization));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.reportsView = reportsView ?? throw new ArgumentNullException(nameof(reportsView));
            this.loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }
        public void Execute()
        {
            loggerService.LogInformation(customMessageStockReport);
            var stockProducts = productRepository.GetAll()
                                                 .Select(p => new StockProduct { Name = p.Name, Quantity = p.Quantity }).ToList();
            fileSerialization.Serilizer(new StockReport(stockProducts), $"Stock Report - {reportsView.DisplayCurrentDateTime()}");
            reportsView.DisplaySuccessMessage();
        }
    }
}
