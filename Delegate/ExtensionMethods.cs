using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class LinqMethods
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(predicate, nameof(predicate));
            foreach (TSource element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(predicate, nameof(predicate));
            foreach (TSource element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(predicate, nameof(predicate));
            foreach (TSource element in source)
            {
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException();
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(selector, nameof(selector));
            foreach (TSource element in source)
            {
                yield return selector(element);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(selector, nameof(selector));
            foreach (TSource element in source)
            {
                foreach (TResult subElement in selector(element))
                {
                    yield return subElement;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(predicate, nameof(predicate));
            foreach (TSource element in source)
            {
                if (predicate(element))
                {
                   yield return element;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(keySelector, nameof(keySelector));
            CheckForNull(elementSelector, nameof(elementSelector));
            Dictionary<TKey, TElement> d = new Dictionary<TKey, TElement>();
            foreach (TSource element in source)
            {
                d.Add(keySelector(element), elementSelector(element));
            }

            return d;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            CheckForNull(first, nameof(first));
            CheckForNull(second, nameof(second));
            CheckForNull(resultSelector, nameof(resultSelector));

            var firstEnum = first.GetEnumerator();
            var secondEnum = second.GetEnumerator();
            while (firstEnum.MoveNext() && secondEnum.MoveNext())
            {
                yield return resultSelector(firstEnum.Current, secondEnum.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(func, nameof(func));
            TAccumulate result = seed;
            foreach (var element in source)
            {
                result = func(result, element);
            }

            return result;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            CheckForNull(outer, nameof(outer));
            CheckForNull(inner, nameof(inner));
            CheckForNull(outerKeySelector, nameof(outerKeySelector));
            CheckForNull(innerKeySelector, nameof(innerKeySelector));
            CheckForNull(resultSelector, nameof(resultSelector));
            foreach (TOuter outerElement in outer)
            {
                TKey outerKey = outerKeySelector(outerElement);
                foreach (TInner innerElement in inner)
                {
                    TKey innerKey = innerKeySelector(innerElement);
                    if (outerKey.Equals(innerKey))
                    {
                        yield return resultSelector(outerElement, innerElement);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            CheckForNull(source, nameof(source));
            HashSet<TSource> set = new HashSet<TSource>(comparer);
            foreach (var element in source)
            {
                if (set.Add(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            CheckForNull(first, nameof(first));
            CheckForNull(second, nameof(second));
            HashSet<TSource> set = new HashSet<TSource>(comparer);
            foreach (var element in first)
            {
                if (set.Add(element))
                {
                    yield return element;
                }
            }

            foreach (var element in second)
            {
                if (set.Add(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            CheckForNull(first, nameof(first));
            CheckForNull(second, nameof(second));
            HashSet<TSource> set = new HashSet<TSource>(comparer);
            foreach (var element in second)
            {
                set.Add(element);
            }

            foreach (var element in first)
            {
                if (set.Remove(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            CheckForNull(first, nameof(first));
            CheckForNull(second, nameof(second));
            HashSet<TSource> set = new HashSet<TSource>(comparer);
            foreach (var element in second)
            {
                set.Add(element);
            }

            foreach (var element in first)
            {
                if (set.Add(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
        IEqualityComparer<TKey> comparer)
        {
            CheckForNull(keySelector, nameof(keySelector));
            CheckForNull(elementSelector, nameof(elementSelector));
            CheckForNull(resultSelector, nameof(resultSelector));
            CheckForNull(source, nameof(source));
            Dictionary<TKey, List<TElement>> d = new Dictionary<TKey, List<TElement>>(comparer);
            foreach (var element in source)
            {
                TKey key = keySelector(element);

                if (d.TryGetValue(key, out List<TElement> tmpList))
                {
                    tmpList.Add(elementSelector(element));
                }

                tmpList = new List<TElement>();
                d.Add(key, tmpList);
            }

            foreach (var kvp in d)
            {
                yield return resultSelector(kvp.Key, kvp.Value);
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(keySelector, nameof(keySelector));
            return new OrderedEnumerable<TSource>(source, new FirstComparer<TSource, TKey>(keySelector, comparer));
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
        this IOrderedEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(keySelector, nameof(keySelector));
            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        internal static TSource[] ToArray<TSource>(this IEnumerable<TSource> source, out int count)
        {
            ICollection<TSource> collection = source as ICollection<TSource>;
            count = collection.Count;
            TSource[] tmp = new TSource[count];
            collection.CopyTo(tmp, 0);
            return tmp;
        }

        private static void CheckForNull<T>(T elementToCheck, string v)
        {
            if (elementToCheck != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(v));
        }
    }
}