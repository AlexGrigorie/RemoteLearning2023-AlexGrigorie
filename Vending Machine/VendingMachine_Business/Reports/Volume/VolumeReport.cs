using VendingMachine_Business.Reports.Stock;

namespace VendingMachine_Business.Reports.Volume
{
    public class VolumeReport
    {
        public DateTime StarDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Product> Sales { get; set; }
    }
}
