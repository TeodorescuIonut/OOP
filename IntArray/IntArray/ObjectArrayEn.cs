using System;
using System.Collections;

namespace Arrays
{
    public class ObjectArrayEn : IEnumerator
    {
        public object[] Objects;
        int position = -1;

        public ObjectArrayEn(object[] objects)
        {
            Objects = objects;
        }

        object IEnumerator.Current
        {
            get
            {
                return Objects[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < Objects.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
