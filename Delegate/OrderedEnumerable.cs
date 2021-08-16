using System;
using System.Collections;
using System.Collections.Generic;

namespace ExtensionMethods
{
    internal class OrderedEnumerable<TElement, TKey> : IOrderedEnumerable<TElement>
    {
        private readonly Func<TElement, TKey> keySelector;
        private readonly IComparer<TKey> comparer;
        private readonly IEnumerable<TElement> source;
        private readonly bool v;

        public OrderedEnumerable(IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool v)
        {
            this.source = source;
            this.keySelector = keySelector;
            this.comparer = comparer;
            this.v = v;
        }

        public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool ascending)
        {
            throw new NotImplementedException();
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
                while (comparer.Compare(keySelector(elements[i]), keySelector(elements[pivot])) < 0)
                {
                    i++;
                }

                while (comparer.Compare(keySelector(elements[j]), keySelector(elements[pivot])) > 0)
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