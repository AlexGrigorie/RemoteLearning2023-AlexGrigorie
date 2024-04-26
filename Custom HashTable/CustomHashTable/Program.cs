namespace CustomHashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<object, object> test = new MyHashTable<object, object>(10);
            test["a"] = "ALex";
            test["a"] = "ALex";
            test["a"] = "ALex";
            test[1] = "Primul";
            test["primul"] = 1;
            Console.WriteLine(test.Count());
        }

    }
}
