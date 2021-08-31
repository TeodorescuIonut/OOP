using System;
using System.Collections;
using System.Collections.Generic;

namespace Inventory
{
    public class Stock
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

        public bool Remove(Product item)
        {           
            if (myList.Contains(item))
            {
                myList.Remove(item);
                Count--;
                CheckStockLevel((quantity, product) => Console.WriteLine(quantity + ":" + product));
                return true;
            }
            return false;

        }

        public void CheckStockLevel(Action<int, Product> stockLevel)
        {
            int[] limits = new int[] { 2, 5, 10 };
            foreach(int limit in limits)
            {
                if(myList.Count < limit && limit == Count + 1)
                {
                    stockLevel(Count, myList[Count - 1]);
                    break;
                }
            }
        }
        
    }
}
