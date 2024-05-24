namespace CustomHashTable
{
    internal class InvalidKey : Exception
    {
        private const string messsage = "Key can not be null or empty!";
        public InvalidKey():base(messsage)
        {
        }
    }
}
