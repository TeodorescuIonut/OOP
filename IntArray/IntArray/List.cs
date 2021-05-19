using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class List<T> : IList<T>
    {
        protected T[] elements;

        public List()
        {
            const int size = 4;
            elements = new T[size];
        }

        public int Count { get; private set; }

        public virtual bool IsReadOnly { get; set; }

        public virtual T this[int index]
        {
            get => elements[index];

            set => elements[index] = value;
        }

        public virtual void Add(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            EnsureCapacity();
            elements[Count] = item;
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
            return Array.IndexOf(elements, item, 0, Count);
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
            elements[index] = item;
            Count++;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            elements = Array.Empty<T>();
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
            Array.Resize(ref elements, Count);
        }

        public void ShiftLeft(int index)
        {
            for (int j = index; j < Count - 1; j++)
            {
                elements[j] = elements[j + 1];
            }
        }

        public void ShiftRight(int index)
        {
            for (int j = Count - 1; j > index; j--)
            {
                elements[j] = elements[j - 1];
            }
        }

        public void EnsureCapacity()
        {
            if (Count < elements.Length)
            {
                return;
            }

            const int sizeDouble = 2;
            Array.Resize(ref elements, elements.Length * sizeDouble);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return elements[i];
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
                array.SetValue(elements[i], arrayIndex++);
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