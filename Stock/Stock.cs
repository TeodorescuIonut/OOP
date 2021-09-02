using System;
using System.Collections;
using System.Collections.Generic;

namespace Inventory
{
    public class Stock
    {
        private List<Product> myList;
        Action<int, Product> stockLevel;
        public bool result = false;
        public Stock()
        {
            myList = new List<Product>();
        }
        public int Count {
            get
            {
                return myList.Count;
            }
        }
        public void Add(Product item)
        {
            if (myList.Contains(item))
            {
                item.Quantity++;
            }
            else
            {
                myList.Add(item);
                item.Quantity++;
            }          
            
        }


        public bool Contains(Product item)
        {
            return myList.Contains(item);
        }
        public void StockAlert(Action<int, Product> stock)
        {
            stockLevel = stock;
            result = true;
        }

        public bool Remove(Product item)
        {           
            if (myList.Contains(item))
            {
                if(item.Quantity == 0)
                {
                    myList.Remove(item);
                }
                else
                {
                    item.Quantity--;
                }
                CheckStockLevel();
                return true;
            }
            return false;

        }


        private void CheckStockLevel()
        {

            int[] limits = new int[] { 2, 5, 10 };
            foreach(int limit in limits)
            {
                foreach(Product item in myList)
                {
                    if (item.Quantity < limit && limit == item.Quantity + 1)
                    {
                        stockLevel(item.Quantity, item);
                        break;
                    }
                }
                
            }
        }

    }
}
