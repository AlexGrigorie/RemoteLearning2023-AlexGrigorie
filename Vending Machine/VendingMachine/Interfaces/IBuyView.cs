namespace iQuest.VendingMachine.Interfaces
{
    internal interface IBuyView
    {
        public int RequestProduct();
        public void DispenseProduct(string productName);
    }
}
