using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Arrays
{
    public class ReadOnlyList<T> : IList<T>
    {
        private const string Error = "Collection is read-only.";

        private readonly IList<T> readonlylist;

        public ReadOnlyList(List<T> list)
        {
            readonlylist = list;
        }

        public bool IsReadOnly { get; set; } = true;

        public virtual int Count
        {
            get { return readonlylist.Count; }
        }

        public T this[int index]
        {
            get { return readonlylist[index]; }
            set => throw new NotSupportedException(Error);
        }

        public void Add(T item)
        {
            throw new NotSupportedException(Error);
        }

        public void Clear()
        {
            throw new NotSupportedException(Error);
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            readonlylist.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return readonlylist.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return readonlylist.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException(Error);
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException(Error);
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException(Error);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
