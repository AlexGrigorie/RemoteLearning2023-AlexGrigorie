using System.Xml.Serialization;

namespace VendingMachine_Business.Reports.Sales
{
    [XmlRoot("SalesReport")]
    public class SalesReports : List<Sale>
    {
        public SalesReports(IEnumerable<Sale> reports) : base(reports)
        {

        }
    }
}
