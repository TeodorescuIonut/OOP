using System;

namespace Arrays
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            array = new int[0];
        }

        public void Add(int element)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = element;
        }

        public int Count()
        {
            return array.Length;
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
            return Array.Exists(array, x => x.Equals(element));
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element);
        }

        public void Insert(int index, int element)
        {
            int[] newarr = new int[array.Length + 1];
            for (int i = 0; i < array.Length + 1; i++)
            {
                if (i < index - 1)
                {
                    newarr[i] = array[i];
                }
                else if (i == index - 1)
                {
                    newarr[i] = element;
                }
                else
                {
                    newarr[i] = array[i - 1];
                }
            }

            array = newarr;
        }

        public void Clear()
        {
            Array.Clear(array, 0, array.Length);
        }

        public void Remove(int element)
        {
            Array.Clear(array, IndexOf(element), 1);
        }

        public void RemoveAt(int index)
        {
            Array.Clear(array, index, 1);
        }
    }
}
