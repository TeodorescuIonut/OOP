using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ReadOnlyList<T>
    {
        private readonly T[] elements;

        public ReadOnlyList()
        {
            const int size = 4;
            elements = new T[size];
        }

        public bool IsReadOnly { get; }

        public int Count { get; }

        public T this[int index]
        {
            get => elements[index];
            set => elements[index] = value;
        }
    }
}
