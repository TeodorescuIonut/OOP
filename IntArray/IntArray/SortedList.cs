using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public override T this[int index]
        {
            get => base[index];
            set
            {
                if (value.CompareTo(ElementAt(index - 1, value)) < 0 || value.CompareTo(ElementAt(index + 1, value)) > 0)
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(T element)
        {
            if (Count == 0 || element.CompareTo(this[0]) <= 0)
            {
                base.Insert(0, element);
                return;
            }

            for (int i = Count; i >= 0; i--)
            {
                if (element.CompareTo(this[i - 1]) > 0)
                {
                    base.Insert(i, element);
                    break;
                }
            }
        }

        public override void Insert(int index, T element)
        {
            if (element.CompareTo(ElementAt(index - 1, element)) < 0 || element.CompareTo(ElementAt(index, element)) > 0)
            {
                return;
            }

            base.Insert(index, element);
        }

        public T ElementAt(int index, T defaultValue)
        {
            return index >= 0 && index < Count ? this[index] : defaultValue;
        }

        public int CompareTo(T other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.CompareTo(other);
        }
    }
}