using System;
using System.Collections;
using System.Collections.Generic;

namespace Inventory
{
    public class Stock<Product> :ICollection<Product>
    {
        private List<Product> myList;

        public Stock()
        {
            myList = new List<Product>();
        }
        public int Count { get; set; }
        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Product item)
        {
            myList.Add(item);
            Count++;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Product item)
        {
            return myList.Contains(item);
        }

        public void CopyTo(Product[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Product item)
        {
            Action<int, Product> notification = new Action<int, Product>(ConsolePrint);
            
            if (myList.Contains(item))
            {
                myList.Remove(item);
                Count--;
                if (myList.Count < 2)
                {
                    notification(Count, item);
                }
                else if (myList.Count < 5)
                {
                    notification(Count, item);
                }
                else if (myList.Count < 10)
                {
                    notification(Count, item);
                }
                return true;
            }
            return false;

        }
        static void ConsolePrint(int i, Product item)
        {
            Console.WriteLine("There are " + i+ " of products " + item);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
