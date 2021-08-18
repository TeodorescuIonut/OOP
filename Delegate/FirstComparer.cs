using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    internal class FirstComparer<TSource, TKey> : IComparer<TSource>
    {
        private readonly Func<TSource, TKey> keySelector;
        private readonly IComparer<TKey> comparer;

        public FirstComparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer;
        }

        public int Compare(TSource x, TSource y)
        {
            TKey keyX = keySelector(x);
            TKey keyY = keySelector(y);
            return comparer.Compare(keyX, keyY);
        }
    }
}