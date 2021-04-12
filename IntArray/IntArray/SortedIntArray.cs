using System;

namespace Arrays
{
    public class SortedIntArray : IntArray
    {
        public override void Add(int element)
        {
            if (Count == 0 || element <= this[0])
            {
                Insert(0, element);
                return;
            }

            for (int i = Count - 1; i >= 0; i--)
                {
                    if (element > this[i])
                    {
                        Insert(i, element);
                        break;
                    }
                }
        }
    }
}
