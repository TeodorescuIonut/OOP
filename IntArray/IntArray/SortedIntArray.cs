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
                if ((index == 0 && value < base[index + 1]) || (index == Count && value > base[index]))
                {
                    base[index] = value;
                    return;
                }
                else if (index != 0 || index != Count || value < base[index - 1] || value > base[index + 1])
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
            if ((index == 0 && element < this[index + 1]) || (index == Count && element > this[index]))
            {
                base.Insert(index, element);
                return;
            }
            else if (index != 0 || index != Count || element < this[index - 1] || element > this[index + 1])
            {
                return;
            }

            base.Insert(index, element);
                    }
    }
}
