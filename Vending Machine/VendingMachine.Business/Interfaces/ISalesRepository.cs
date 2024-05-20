using VendingMachine.Business.Reports.Sales;
using VendingMachine.Business.Reports.Stock;
using VendingMachine.Business.Reports.Volume;

namespace VendingMachine.Business.Interfaces
{
    internal interface ISalesRepository
    {
       public IEnumerable<Sales> GetAllSales();
       public IEnumerable<StockProduct> GetProductsBySpecificPeriod(TimeInterval timeInterval);
    }
}
