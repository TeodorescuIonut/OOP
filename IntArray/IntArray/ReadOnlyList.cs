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

        private readonly List<T> mylist;

        public ReadOnlyList(List<T> list)
        {
            if (list == null)
            {
                return;
            }

            mylist = list;
        }

        public bool IsReadOnly { get; set; } = true;

        public virtual int Count
        {
            get { return mylist.Count; }
        }

        public T this[int index]
        {
            get { return mylist[index]; }
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
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentException("Received a null argument!", nameof(array));
            }

            if (Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException("The destination array has fewer elements than the collection.", nameof(array));
            }

            for (int i = 0; i < Count; i++)
            {
                array.SetValue(this[i], arrayIndex++);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.mylist.Elements, item, 0, Count);
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
