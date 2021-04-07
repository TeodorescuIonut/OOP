using System;

namespace Arrays
{
    public class SortedIntArray : IntArray
    {
        public void AddInOrder(int element)
        {
            if (Count == 0)
            {
                Add(element);
            }

            EnsureCapacity();
            int i = Count;
            while (i > 0 && i <= Count)
                {
                    this[i] = this[i - 1];
                    if (element > this[i - 1])
                    {
                        Insert(i, element);
                        break;
                    }
                    else if (element == this[i])
                    {
                        this[i] = this[i - 1];
                        break;
                    }

                    i--;
            }
        }
    }
}
