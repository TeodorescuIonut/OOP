using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class List<T> : IList<T>
    {
        private T[] elements;

        public List()
        {
            const int size = 4;
            elements = new T[size];
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual T this[int index]
        {
            get => elements[index];
            set => elements[index] = value;
        }

        public virtual void Add(T item)
        {
            EnsureCapacity();
            elements[Count] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(elements, item, 0, Count);
        }

        public virtual void Insert(int index, T item)
        {
            EnsureCapacity();
            ShiftRight(index);
            elements[index] = item;
            Count++;
        }

        public void Clear()
        {
            elements = Array.Empty<T>();
            Count = 0;
        }

        public void Remove(T element)
        {
            int index = IndexOf(element);
            if (index == -1)
            {
                return;
            }

            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
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
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
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
    }
}
