using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class List<T> : IList<T>
    {
        public T[] Elements;

        public List()
        {
            const int size = 4;
            Elements = new T[size];
        }

        public virtual int Count { get; protected set; }

        public virtual bool IsReadOnly { get; set; }

        public virtual T this[int index]
        {
            get => Elements[index];

            set => Elements[index] = value;
        }

        public virtual void Add(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            EnsureCapacity();
            Elements[Count] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(Elements, item, 0, Count);
        }

        public virtual void Insert(int index, T item)
        {
            ValidateIndex(index, Count);
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            EnsureCapacity();
            ShiftRight(index);
            Elements[index] = item;
            Count++;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            Elements = Array.Empty<T>();
            Count = 0;
        }

        public void Remove(T element)
        {
            int index = IndexOf(element);
            ValidateIndex(index, Count - 1);
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index, Count - 1);
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            ShiftLeft(index);
            Count--;
            Array.Resize(ref Elements, Count);
        }

        public void ShiftLeft(int index)
        {
            for (int j = index; j < Count - 1; j++)
            {
                Elements[j] = Elements[j + 1];
            }
        }

        public void ShiftRight(int index)
        {
            for (int j = Count - 1; j > index; j--)
            {
                Elements[j] = Elements[j - 1];
            }
        }

        public void EnsureCapacity()
        {
            if (Count < Elements.Length)
            {
                return;
            }

            const int sizeDouble = 2;
            Array.Resize(ref Elements, Elements.Length * sizeDouble);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ValidateIndex(arrayIndex, Count - 1);
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
                array.SetValue(Elements[i], arrayIndex++);
            }
        }

        bool ICollection<T>.Remove(T item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }

            Remove(item);
            return true;
        }

        public void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public void ValidateIndex(int index, int itemsCount)
        {
            if (index >= 0 && index <= itemsCount)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range");
        }
    }
}