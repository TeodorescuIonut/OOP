using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dictionary
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        internal int FreeIndex;
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
                int i = FindEntry(key);
                if (i >= 0)
                {
                    return entries[i].Value;
                }

                throw new ArgumentNullException(nameof(key));
            }

            set
            {
                Add(key, value);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Initialize(int capacity)
        {
            buckets = new int[capacity];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            entries = new Entry[capacity];
            FreeIndex = -1;
        }

        public void Add(TKey key, TValue value)
        {
            CheckForNull(key);
            int bucketIndex = GetBucket(key);
            int lastFree;
            if (FreeIndex != -1)
            {
                entries[FreeIndex].Value = value;
                entries[FreeIndex].Key = key;
                lastFree = entries[FreeIndex].Next;
                entries[FreeIndex].Next = buckets[bucketIndex];
                buckets[bucketIndex] = FreeIndex;
                FreeIndex = lastFree;
            }
            else if (buckets[bucketIndex] == -1)
            {
                buckets[bucketIndex] = Count;
                entries[Count].Value = value;
                entries[Count].Key = key;
                entries[Count].Next = -1;
            }
            else
            {
                entries[Count].Next = buckets[bucketIndex];
                buckets[bucketIndex] = Count;
                entries[Count].Value = value;
                entries[Count].Key = key;
            }

            Count++;
        }

        public int GetBucket(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            return hash % buckets.Length;
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

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            Array.Clear(entries, 0, Count);
            FreeIndex = -1;
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public bool ContainsKey(TKey key)
        {
            CheckForNull(key);
            int bucketIndex = GetBucket(key);
            int position = buckets[bucketIndex];
            while (position < buckets.Length && position != -1)
            {
                if (entries[position].Key.Equals(key))
                {
                    return true;
                }

                position = entries[position].Next;
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentException("Received a null argument!", nameof(array));
            }

            for (int i = arrayIndex; i < entries.Length; i++)
            {
                array[i] = new KeyValuePair<TKey, TValue>(entries[i].Key, entries[i].Value);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < entries.Length; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(entries[i].Key, entries[i].Value);
            }
        }

        public bool Remove(TKey key)
            {
            CheckForNull(key);
            int bucketIndex = GetBucket(key);
            int deletedElementIndex = buckets[bucketIndex];
            if (!ContainsKey(key))
            {
                return false;
            }

            while (deletedElementIndex < buckets.Length && deletedElementIndex != -1)
            {
                if (entries[deletedElementIndex].Key.Equals(key))
                {
                    if (entries[deletedElementIndex].Next != -1)
                    {
                        entries[deletedElementIndex + 1].Next = entries[deletedElementIndex].Next;
                        entries[deletedElementIndex].Next = FreeIndex;
                        FreeIndex = deletedElementIndex;
                        Count--;
                        return true;
                    }

                    if (FreeIndex != -1)
                    {
                        entries[deletedElementIndex].Next = FreeIndex;
                    }

                    buckets[bucketIndex] = -1;
                    FreeIndex = deletedElementIndex;
                    Count--;
                    return true;
                }

                deletedElementIndex = entries[deletedElementIndex].Next;
            }

            return false;
            }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
            {
            CheckForNull(key);
            if (!ContainsKey(key))
            {
                value = default;
                return default;
            }

            value = this[key];
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckForNull(TKey key)
            {
            if (key != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(key));
        }

        private int FindEntry(TKey key)
        {
            CheckForNull(key);
            int bucketIndex = GetBucket(key);
            int i = buckets[bucketIndex];
            while (i < buckets.Length && i != -1)
            {
                if (entries[i].Key.Equals(key))
                {
                    return i;
                }

                i = entries[i].Next;
            }

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
