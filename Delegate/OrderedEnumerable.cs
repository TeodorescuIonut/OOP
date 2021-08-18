using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
    internal class OrderedEnumerable<TElement> : IOrderedEnumerable<TElement>
    {
        private readonly IEnumerable<TElement> source;
        private readonly IComparer<TElement> currentComparer;

        internal OrderedEnumerable(IEnumerable<TElement> source, IComparer<TElement> comparer)
        {
            this.source = source;
            this.currentComparer = comparer;
        }

        public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            IComparer<TElement> secondaryComparer = new FirstComparer<TElement, TKey>(keySelector, comparer);

            return new OrderedEnumerable<TElement>(source, new SecondComparer<TElement>(currentComparer, secondaryComparer));
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            int count;
            TElement[] data = source.ToArray(out count);
            QuickSort(data);
            for (int i = 0; i < count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void QuickSort(TElement[] elements)
        {
            int length = elements.Length;
            const int low = 0;
            int high = length - 1;
            QuickSort(low, high, ref elements);
        }

        private void QuickSort(int low, int high, ref TElement[] elements)
        {
            int i = low;
            int j = high;
            TElement tmp;
            int pivot = (low + high) / 2;
            while (i <= j)
            {
                while (currentComparer.Compare(elements[i], elements[pivot]) < 0)
                {
                    i++;
                }

                while (currentComparer.Compare(elements[j], elements[pivot]) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;
                    i++;
                    j--;
                }

                if (low < j)
                {
                    QuickSort(low, j, ref elements);
                }

                if (i >= high)
                {
                    return;
                }

                QuickSort(i, high, ref elements);
            }
        }
    }
}