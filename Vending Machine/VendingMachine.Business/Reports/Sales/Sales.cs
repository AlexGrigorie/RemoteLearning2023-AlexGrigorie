using Product = VendingMachine.Business.Entities.Product;
namespace VendingMachine.Business.Reports.Sales
{
    internal class Sales
    {
        public string PaymentMethod { get; set; }
        public DateTime SaleDate { get; set; }
        public Product Product { get; set; }
    }
}
