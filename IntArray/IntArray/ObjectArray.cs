using System;
using System.Collections;
using System.Text;

namespace Arrays
{
    public class ObjectArrayCollection : IEnumerable
    {
        private object[] objects;

        public ObjectArrayCollection()
        {
            const int size = 4;
            objects = new object[size];
        }

        public int Count { get; private set; }

        public object this[int index]
        {
            get => objects[index];
            set => objects[index] = value;
        }

        public virtual void Add(object element)
        {
            EnsureCapacity();
            objects[Count] = element;
            Count++;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(object element)
        {
            return Array.IndexOf(objects, element, 0, Count);
        }

        public void Insert(int index, object element)
        {
            EnsureCapacity();
            ShiftRight(index);
            objects[index] = element;
            Count++;
        }

        public void Clear()
        {
            objects = Array.Empty<object>();
            Count = 0;
        }

        public void Remove(object element)
        {
            int index = IndexOf(element);
            if (index == -1)
            {
                return;
            }

            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
            Array.Resize(ref objects, Count);
        }

        public void ShiftLeft(int index)
        {
            for (int j = index; j < Count - 1; j++)
            {
                objects[j] = objects[j + 1];
            }
        }

        public void ShiftRight(int index)
        {
            for (int j = Count; j > index; j--)
            {
                objects[j] = objects[j - 1];
            }
        }

        public void EnsureCapacity()
        {
            if (Count < objects.Length)
            {
                return;
            }

            const int sizeDouble = 2;
            Array.Resize(ref objects, objects.Length * sizeDouble);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ObjectArrayEn GetEnumerator()
        {
            object[] newObjArray = new object[Count];
            for (int i = 0; i < Count; i++)
            {
                    newObjArray[i] = objects[i];
            }

            return new ObjectArrayEn(newObjArray);
        }
    }
}
