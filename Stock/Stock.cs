using System;
using System.Collections;
using System.Collections.Generic;

namespace Inventory
{
    public class Stock
    {
        private List<Product> myList;
        Action<int, Product> stockLevel;
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
                CheckStockLevel();
                return true;
            }
            return false;

        }

        public void CheckStockLevel()
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
        public void StockLevel(Action<int, Product> stock)
        {
            stockLevel = stock;
        }
    }
}
