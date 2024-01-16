namespace iQuest.VendingMachine.Entities
{
    internal class Product
    {
        public int Id { get; set; }
        public int ColumnId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
