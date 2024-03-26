using Product = VendingMachine_Business.Entities.Product;
namespace VendingMachine_Business.Reports.Sales
{
    internal class Sales
    {
        public string PaymentMethod { get; set; }
        public DateTime SaleDate { get; set; }
        public Product Product { get; set; }
    }
}
