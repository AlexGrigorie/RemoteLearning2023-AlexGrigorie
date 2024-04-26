
namespace CustomHashTable
{
    public class MyHashTable<TKey, TValue>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<TKey, TValue>>[] items;
        public MyHashTable(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }

        public void Put(TKey key, TValue value) 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            KeyValuePair<TKey, TValue> item = new KeyValuePair<TKey, TValue>(key, value);
            linkedList.AddLast(item);
        }

        public TValue Get(TKey key) 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            foreach(KeyValuePair<TKey, TValue> item in linkedList)
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
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValuePair<TKey, TValue> foundItem = default(KeyValuePair<TKey, TValue>);
            foreach (KeyValuePair<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    foundItem = item;
                    itemFound = true;
                    break;
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
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            bool isKey = false;
            foreach (KeyValuePair<TKey, TValue> item in linkedList)
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

        private LinkedList<KeyValuePair<TKey, TValue>> GetLinkedList(int position)
        {
           LinkedList<KeyValuePair<TKey, TValue>> linkedList = items[position];
           if(linkedList == null) 
           {
                linkedList = new LinkedList<KeyValuePair<TKey, TValue>>();
                items[position] = linkedList;
           }
           return linkedList;
        }

        private int GetArrayPosition(TKey key)
        {
            if(key == null || key.ToString() == "") 
            {
                throw new InvalidKey();
            }
            var hashCode = key.GetHashCode();
            int postion = hashCode % size;
            return Math.Abs(postion);
        }
    }
}
