using System;

namespace Arrays
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            const int size = 4;
            array = new int[size];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(int element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element, 0, Count);
        }

        public void Insert(int index, int element)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            array = Array.Empty<int>();
            Count = 0;
        }

        public void Remove(int element)
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
            Array.Resize(ref array, Count);
        }

        public void ShiftLeft(int index)
        {
            for (int j = index; j < Count - 1; j++)
            {
                array[j] = array[j + 1];
            }
        }

        public void ShiftRight(int index)
        {
            for (int j = Count; j > index; j--)
            {
                array[j] = array[j - 1];
            }
        }

        public void EnsureCapacity()
            {
            if (Count < array.Length)
            {
                return;
            }

            const int sizeDouble = 2;
            Array.Resize(ref array, array.Length * sizeDouble);
        }
    }
}