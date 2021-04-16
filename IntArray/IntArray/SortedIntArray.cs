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
                if (Valid(index, value))
                {
                    base[index] = value;
                    return;
                }
                else if (!Valid(index, value))
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
            if (Valid(index, element))
            {
                base.Insert(index, element);
                return;
            }
            else if (!Valid(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        public bool Valid(int index, int insertedValue)
        {
            if ((index == 0 && insertedValue < this[index + 1]) || (index == Count && insertedValue > this[index]))
            {
                return true;
            }
            else if (index != 0 || index != Count || insertedValue < this[index - 1] || insertedValue > this[index + 1])
            {
                return false;
            }

            return false;
        }
    }
}
