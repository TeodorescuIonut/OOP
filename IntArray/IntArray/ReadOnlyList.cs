using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ReadOnlyList<T>
    {
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
    }
}
