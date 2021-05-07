using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public abstract class ReadOnlyList<T>
    {
        public bool IsReadOnly { get; }

        public int Count { get; }

        public abstract T this[int index]
        {
            get;
            set;
        }
    }
}
