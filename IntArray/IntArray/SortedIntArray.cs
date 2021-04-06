using System;

namespace Arrays
{
    public class SortedIntArray : IntArray
    {
        public void Sort()
        {
         Array.Sort(array, 0, Count);
        }
    }
}
