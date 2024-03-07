namespace CustomHashTable.Tests
{
    [TestClass]
    public class CustomHashTableTests
    {
        [TestMethod]
        public void CustomHashTable_Put_ContainsKeyTrue()
        {
            var hashTable = new MyHashTable<string, string>(4);
            hashTable.Put("a", "Alex");

            bool isKey = hashTable.ContainsKey("a");
            Assert.IsTrue(isKey);
        }

        [TestMethod]
        public void CustomHashTable_Get_EqualValue()
        {
            var hashTable = new MyHashTable<string, int>(4);
            hashTable.Put("year", 1998);

            int year = hashTable.Get("year");
            Assert.AreEqual(1998, year);
        }
        [TestMethod]
        public void CustomHashTable_Remove_ContainsKeyFalse()
        {
            var hashTable = new MyHashTable<string, int>(4);
            hashTable.Put("year", 1998);
            hashTable.Remove("year");

            bool isRemoved = hashTable.ContainsKey("year");
            Assert.IsFalse(isRemoved);
        }
        [TestMethod]
        public void CustomHashTable_Count_EqualNumberOfElements()
        {
            var hashTable = new MyHashTable<string, int>(4);
            hashTable.Put("year", 1998);
            hashTable.Put("month", 6);
            hashTable.Put("day", 13);

            int expectedNumberOfElements = 3;
            int count = hashTable.Count();

            Assert.AreEqual(expectedNumberOfElements, count);
        }

        [TestMethod]
        public void CustomHashTable_ContainsKey_FalseKeyDoesntExist()
        {
            var hashTable = new MyHashTable<string, int>(4);
            hashTable.Put("year", 1998);
            hashTable.Put("month", 6);
            hashTable.Put("day", 13);

            Assert.IsFalse(hashTable.ContainsKey("invalidKey"));
        }

        [TestMethod]
        public void CustomHashTable_ContainsKey_TrueKeyExists()
        {
            var hashTable = new MyHashTable<string, int>(4);
            hashTable.Put("year", 1998);
            hashTable.Put("month", 6);
            hashTable.Put("day", 13);

            Assert.IsTrue(hashTable.ContainsKey("month"));
        }

        [TestMethod]
        public void CustomHashTable_Indexer_EqualValues()
        {
            var hashTable = new MyHashTable<string, int>(4);
            hashTable["year"] = 1998;
            int year = hashTable["year"];

            Assert.AreEqual(hashTable["year"], year);
        }
    }
}