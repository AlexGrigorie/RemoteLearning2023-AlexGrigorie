using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Reports.Sales;

namespace VendingMachine.Business.UseCases
{
    internal class SalesReportUseCase : IUseCase
    {
        private readonly ISalesRepository salesRepository;
        private readonly IReportsView reportsView;
        private readonly IFileSerialization fileSerialization;

        public SalesReportUseCase(ISalesRepository salesRepository, IReportsView reportsView, IFileSerialization fileSerialization)
        {
            this.salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            this.reportsView = reportsView ?? throw new ArgumentNullException(nameof(reportsView));
            this.fileSerialization = fileSerialization ?? throw new ArgumentNullException(nameof(fileSerialization));
        }

        public void Execute()
        {
            reportsView.AskForTimeInterval();
            var startDate = reportsView.AskForStartDate().Date;
            var endDate = reportsView.AskForEndDate().Date;

            if (!ConflictWith(startDate, endDate))
            {
                var salesProducts = salesRepository.GetAllSales()
                  .Where(x => x.SaleDate.Date >= startDate || x.SaleDate.Date >= endDate)
                  .Select(x => new Sale { Date = x.SaleDate, Name = x.Product.Name, Price = x.Product.Price, PaymentMethod = x.PaymentMethod })
                  .ToList();
                fileSerialization.Serilizer(new SalesReports(salesProducts), $"Sales Report - {reportsView.DisplayCurrentDateTime()}");
                reportsView.DisplaySuccessMessage();
            }
            else
                throw new ConflictDatesException();
        }

        private bool ConflictWith(DateTime startDate, DateTime endDate)
        {
            return startDate > endDate;
        }
    }
}
