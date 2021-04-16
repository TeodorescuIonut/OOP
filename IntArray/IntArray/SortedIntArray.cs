using System;

namespace Arrays
{
    public class SortedIntArray : IntArray
    {
        public override int this[int index]
        {
            get => base[index];
            set
            {
                if (value < ElementAt(index - 1, value) || value > ElementAt(index + 1, value))
                {
                    return;
                }

                base[index] = value;
            }
            }

        public override void Add(int element)
        {
            if (Count == 0 || element <= this[0])
            {
                base.Insert(0, element);
                return;
            }

            for (int i = Count - 1; i >= 0; i--)
                {
                    if (element > this[i - 1])
                    {
                        base.Insert(i, element);
                        break;
                    }
                }
        }

        public override void Insert(int index, int element)
                {
             if (element < ElementAt(index - 1, element) || element > ElementAt(index, element))
            {
                return;
            }

             base.Insert(index, element);
        }

        public int ElementAt(int index, int defaultValue)
        {
            return index >= 0 && index < Count ? this[index] : defaultValue;
        }
    }
}
