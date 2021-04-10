using System;

namespace Arrays
{
    public class SortedIntArray : IntArray
    {
        public override void Add(int element)
        {
            for (int i = Count; i >= 0; i--)
            {
                if (Count == 0)
                {
                    Insert(0, element);
                    break;
                }
                else if (element <= this[0])
                {
                    this[i] = this[i - 1];
                    Insert(0, element);
                    break;
                }
                else if (element >= this[i - 1])
                {
                    Insert(i, element);
                    break;
                }

                this[i] = this[i - 1];
            }
        }
        }
    }
