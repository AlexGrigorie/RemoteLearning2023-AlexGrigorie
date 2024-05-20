using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Reports.Stock;

namespace VendingMachine.Business.UseCases
{
    internal class StockReportUseCase : IUseCase
    {
        private readonly IFileSerialization fileSerialization;
        private readonly IProductRepository productRepository;
        private readonly IReportsView reportsView;

        public StockReportUseCase(IFileSerialization fileSerialization, IProductRepository productRepository, IReportsView reportsView)
        {
            this.fileSerialization = fileSerialization ?? throw new ArgumentNullException(nameof(fileSerialization));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.reportsView = reportsView ?? throw new ArgumentNullException(nameof(reportsView)); ;
        }
        public void Execute()
        {
            var stockProducts = productRepository.GetAll()
                                                 .Select(p => new StockProduct { Name = p.Name, Quantity = p.Quantity }).ToList();
            fileSerialization.Serilizer(new StockReport(stockProducts), $"Stock Report - {reportsView.DisplayCurrentDateTime()}");
            reportsView.DisplaySuccessMessage();
        }
    }
}
