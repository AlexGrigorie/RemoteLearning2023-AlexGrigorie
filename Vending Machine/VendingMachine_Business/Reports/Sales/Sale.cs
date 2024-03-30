namespace VendingMachine_Business.Reports.Sales
{
    public class Sale
    {
        public DateTime Date { set; get; }
        public string Name { set; get; }
        public float Price { set; get; }
        public string PaymentMethod { set; get; }
    }
}
