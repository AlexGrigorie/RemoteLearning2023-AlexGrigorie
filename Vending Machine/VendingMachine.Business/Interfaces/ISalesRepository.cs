using VendingMachine.Business.Reports.Sales;
using VendingMachine.Business.Reports.Stock;
using VendingMachine.Business.Reports.Volume;

namespace VendingMachine.Business.Interfaces
{
    internal interface ISalesRepository
    {
        IEnumerable<Sales> GetAllSales();
        IEnumerable<Product> GetGroupedByProduct(TimeInterval timeInterval);
    }
}
