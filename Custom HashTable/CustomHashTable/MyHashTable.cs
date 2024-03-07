
namespace CustomHashTable
{
    public class MyHashTable<TKey, TValue>
    {
        private readonly int size;
        private readonly LinkedList<KeyValueData<TKey, TValue>>[] items;
        public MyHashTable(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValueData<TKey, TValue>>[size];
        }

        public void Put(TKey key, TValue value) 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValueData<TKey, TValue>> linkedList = GetLinkedList(position);
            KeyValueData<TKey, TValue> item = new KeyValueData<TKey, TValue> { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        public TValue Get(TKey key) 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValueData<TKey, TValue>> linkedList = GetLinkedList(position);
            foreach(KeyValueData<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(TValue);
        }
        public void Remove(TKey key) 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValueData<TKey, TValue>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValueData<TKey, TValue> foundItem = default(KeyValueData<TKey, TValue>);
            foreach (KeyValueData<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    foundItem = item;
                    itemFound = true;
                }
            }
            if (itemFound) 
            {
                linkedList.Remove(foundItem);
            }
        }
        public int Count()
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item != null)
                    count += item.Count;
            }
            return count;
        }
        public bool ContainsKey(TKey key) 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValueData<TKey, TValue>> linkedList = GetLinkedList(position);
            bool isKey = false;
            foreach (KeyValueData<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    isKey = true;
                }
            }
            return isKey;
        }

        public TValue this[TKey key]
        {
            get => Get(key);
            set => Put(key, value);
        }

        private LinkedList<KeyValueData<TKey, TValue>> GetLinkedList(int position)
        {
           LinkedList<KeyValueData<TKey, TValue>> linkedList = items[position];
           if(linkedList == null) 
           {
                linkedList = new LinkedList<KeyValueData<TKey, TValue>>();
                items[position] = linkedList;
           }
           return linkedList;
        }

        private int GetArrayPosition(TKey key)
        {
            var hashCode = key.GetHashCode();
            int postion = hashCode % size;
            return Math.Abs(postion);
        }

        private struct KeyValueData<TKey, TValue> 
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }
    }
}
