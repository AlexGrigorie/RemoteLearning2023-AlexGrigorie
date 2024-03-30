using VendingMachine_Business.Reports.Sales;
using VendingMachine_Business.Reports.Stock;
using VendingMachine_Business.Reports.Volume;

namespace VendingMachine_Business.Interfaces
{
    internal interface ISalesRepository
    {
        IEnumerable<Sales> GetAllSales();
        IEnumerable<Product> GetGroupedByProduct(TimeInterval timeInterval);
    }
}
