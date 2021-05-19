using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ReadOnlyList<T> : List<T>
    {
        public ReadOnlyList(List<T> list) : base()
        {
            if (list == null)
            {
                return;
            }

            list.CopyTo(elements, 0);
        }

        public override bool IsReadOnly { get; set; } = true;

        public new T this[int index]
        {
            get => this[index];
        }
    }
}
