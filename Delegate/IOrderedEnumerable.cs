using System.Collections.Generic;

namespace ExtensionMethods
{
    public interface IOrderedEnumerable<out TElement> : IEnumerable<TElement>
    {
    }
}