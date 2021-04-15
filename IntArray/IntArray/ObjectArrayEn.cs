using System;
using System.Collections;

namespace Arrays
{
    public class ObjectArrayEn : IEnumerator
    {
        private readonly object[] objects;
        int position = -1;

        public ObjectArrayEn(object[] objects)
        {
            this.objects = objects;
        }

        public object Current
        {
            get { return objects[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return position < objects.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
