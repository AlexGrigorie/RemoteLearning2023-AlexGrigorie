using System.Xml.Serialization;

namespace VendingMachine.Business.Reports.Stock
{
    [XmlRoot("StockReport")]
    public class StockReport : List<StockProduct>
    {
        public StockReport(IEnumerable<StockProduct> reports) : base(reports){}
    }
}
