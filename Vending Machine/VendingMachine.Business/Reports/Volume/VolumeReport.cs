using VendingMachine.Business.Reports.Stock;

namespace VendingMachine.Business.Reports.Volume
{
    public class VolumeReport
    {
        public DateTime StarDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Product> Sales { get; set; }
    }
}
