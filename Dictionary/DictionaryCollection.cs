using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dictionary
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int freeIndex;
        private int[] buckets;
        private Entry[] entries;

        public MyDictionary(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            Initialize(capacity);
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                foreach (var entryValue in this)
                {
                    keys.Add(entryValue.Key);
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();
                foreach (var entryValue in this)
                {
                    values.Add(entryValue.Value);
                }

                return values;
            }
        }

        public int Count { get; protected set; }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public TValue this[TKey key]
        {
            get
            {
                int i = FindEntry(key, out int previndex);
                if (i >= 0)
                {
                    return entries[i].Value;
                }

                throw new ArgumentNullException(nameof(key));
            }

            set
            {
                int i = FindEntry(key, out int previndex);
                if (i >= 0)
                {
                    entries[i].Value = value;
                    return;
                }

                Add(key, value);
            }
        }

        public void Initialize(int capacity)
        {
            buckets = new int[capacity];
            Array.Fill(buckets, -1);
            entries = new Entry[capacity];
            freeIndex = -1;
        }

        public void Add(TKey key, TValue value)
        {
            CheckForNull(key);
            int bucketIndex = GetBucket(key);
            int lastFree;
            if (ContainsKey(key))
            {
                throw new ArgumentException("Key already exist in this dictionary", nameof(key));
            }

            if (freeIndex != -1)
            {
                entries[freeIndex].Value = value;
                entries[freeIndex].Key = key;
                lastFree = entries[freeIndex].Next;
                entries[freeIndex].Next = buckets[bucketIndex];
                buckets[bucketIndex] = freeIndex;
                freeIndex = lastFree;
            }
            else
            {
                int entriesIndex = Count;
                entries[entriesIndex].Value = value;
                entries[entriesIndex].Key = key;
                entries[entriesIndex].Next = buckets[bucketIndex];
                buckets[bucketIndex] = entriesIndex;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
            {
            if (Count <= 0)
            {
                return;
            }

            Array.Fill(buckets, -1);
            Array.Clear(entries, 0, Count);
            freeIndex = -1;
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int i = FindEntry(item.Key, out _);
            TValue checkValue = entries[i].Value;
            return i >= 0 && checkValue.Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            CheckForNull(key);
            int i = FindEntry(key, out int previndex);
            return i >= 0;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Received a null argument!");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "index is out of range");
            }

            if (array.Length < this.Count)
            {
                throw new ArgumentException("Array size is smaller than dictionary size", nameof(array));
            }

            foreach (KeyValuePair<TKey, TValue> item in this)
                {
                if (arrayIndex == array.Length)
                {
                    break;
                }

                array[arrayIndex] = item;
                arrayIndex++;
            }
            }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int lastfree;
            for (int i = 0; i < entries.Length; i++)
            {
                if (buckets[i] == -1)
                {
                    continue;
                }

                while (freeIndex != -1)
                {
                    lastfree = entries[freeIndex].Next;
                    freeIndex = lastfree;
                }

                yield return new KeyValuePair<TKey, TValue>(entries[i].Key, entries[i].Value);
            }
        }

        public bool Remove(TKey key)
        {
            CheckForNull(key);
            int bucketIndex = GetBucket(key);
            if (!ContainsKey(key))
            {
                return false;
            }

            int deletedElementIndex = FindEntry(key, out int prevIndex);
            if (prevIndex == deletedElementIndex)
            {
                buckets[bucketIndex] = entries[deletedElementIndex].Next;
                entries[deletedElementIndex].Next = freeIndex;
                freeIndex = deletedElementIndex;
                Count--;
                return true;
            }

            buckets[bucketIndex] = prevIndex;
            entries[prevIndex].Next = entries[deletedElementIndex].Next;
            entries[deletedElementIndex].Next = freeIndex;
            freeIndex = deletedElementIndex;
            Count--;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int i = FindEntry(item.Key, out int previndex);
            TValue checkValue = entries[i].Value;
            return i >= 0 && checkValue.Equals(item.Value) && Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
            {
            CheckForNull(key);
            int i = FindEntry(key, out int previndex);
            if (i < 0)
            {
                value = default;
                return default;
            }

            value = entries[i].Value;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetBucket(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            return hash % buckets.Length;
        }

        private void CheckForNull(TKey key)
            {
            if (key != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(key));
        }

        private int FindEntry(TKey key, out int prevIndex)
        {
            CheckForNull(key);

            int bucketIndex = GetBucket(key);
            int position = buckets[bucketIndex];
            prevIndex = position;
            for (int i = position; i >= 0; i = entries[i].Next)
            {
                if (entries[i].Key.Equals(key))
                {
                    return i;
                }

                prevIndex = i;
            }

            prevIndex = -1;
            return -1;
        }

        private struct Entry
        {
            public int Next;
            public TKey Key;
            public TValue Value;
        }
    }
}
