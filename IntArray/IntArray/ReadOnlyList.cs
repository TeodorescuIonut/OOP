using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ReadOnlyList<T> : List<T>
    {
        private readonly List<T> list;

        public ReadOnlyList(List<T> mylist) : base()
        {
            list = mylist;
        }

        public override bool IsReadOnly { get; set; } = true;

        public override T this[int index]
        {
            get => base[index];
        }

        public override void Add(T item)
            {
            if (!IsReadOnly)
            {
                return;
            }

            throw new ArgumentException("Readonly");
        }
    }
}
