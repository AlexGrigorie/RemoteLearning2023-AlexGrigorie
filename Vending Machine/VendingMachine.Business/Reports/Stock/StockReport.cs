using System.Xml.Serialization;

namespace VendingMachine.Business.Reports.Stock
{
    [XmlRoot("StockReport")]
    public class StockReport : List<Product>
    {
        public StockReport(IEnumerable<Product> reports) : base(reports)
        {

        }
    }
}
