using System;
using System.Collections;
using System.Collections.Generic;

namespace Inventory
{
    public class Stock<Product>
    {
        private List<Product> myList;
        public Stock()
        {
            myList = new List<Product>();
        }
        public int Count { get; set; }
        public void Add(Product item)
        {
            myList.Add(item);
            Count++;
        }


        public bool Contains(Product item)
        {
            return myList.Contains(item);
        }

        public bool Remove(Product item, Action<int, Product> stockLevel)
        {   
            if (myList.Contains(item))
            {
                myList.Remove(item);
                Count--;
                if (myList.Count < 2)
                {
                    stockLevel(Count, item);
                }
                else if (myList.Count < 5)
                {
                    stockLevel(Count, item);
                }
                else if (myList.Count < 10)
                {
                    stockLevel(Count, item);
                }
                return true;
            }
            return false;

        }
        
    }
}
