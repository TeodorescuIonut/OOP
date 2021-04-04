using System;

namespace Arrays
{
    public class IntArray
    {
        private int[] array;
        private int count;

        public IntArray()
        {
            const int size = 4;
            array = new int[size];
        }

        public void Add(int element)
        {
            EnsureCapacity();
            SetElement(count, element);
            count++;
        }

        public int Count()
        {
            return count;
        }

        public int Element(int index)
        {
            return (int)array.GetValue(index);
        }

        public void SetElement(int index, int element)
        {
            array.SetValue(element, index);
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element, 0, count);
        }

        public void Insert(int index, int element)
        {
            EnsureCapacity();
            ShiftRight(index);
            SetElement(index, element);
            count++;
        }

        public void Clear()
        {
            array = Array.Empty<int>();
            count = 0;
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
            count--;
            Array.Resize(ref array, count);
        }

        public void ShiftLeft(int index)
        {
            for (int j = index; j < Count() - 1; j++)
            {
                SetElement(j, Element(j + 1));
            }
        }

        public void ShiftRight(int index)
        {
            for (int j = Count() - 1; j > index; j--)
            {
                SetElement(j, Element(j - 1));
            }
        }

        public void EnsureCapacity()
            {
            if (count < array.Length)
            {
                return;
            }

            const int sizeDouble = 2;
            Array.Resize(ref array, array.Length * sizeDouble);
        }
    }
}