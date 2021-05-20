using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ReadOnlyList<T> : List<T>
    {
        public ReadOnlyList(ref List<T> list)
        {
            if (list == null)
            {
                return;
            }

            list.IsReadOnly = true;
        }

        public override bool IsReadOnly { get; set; } = true;

        public new T this[int index]
        {
            get => this[index];
        }
    }
}
