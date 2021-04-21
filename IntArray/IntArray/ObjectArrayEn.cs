using System;
using System.Collections;

namespace Arrays
{
    public class ObjectArrayEn : IEnumerator
    {
        private readonly ObjectArrayCollection objects;
        int position = -1;

        public ObjectArrayEn(ObjectArrayCollection objects)
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
            return position < objects.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
