using VendingMachine.Business.Reports.Stock;

namespace VendingMachine.Business.Reports.Volume
{
    public class VolumeReport
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<StockProduct> Sales { get; set; }
    }
}
