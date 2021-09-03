using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public int Count {
            get
            {
                return myList.Count;
            }
        }
        public void Add(Product item, int addedQuantity)
        {
            if( addedQuantity == 0)
            {
                throw new ArgumentException("Please enter a higher quantity", nameof(addedQuantity));
            }
            if (myList.Contains(item))
            {
                item.Quantity =+ addedQuantity;
            }
            else
            {
                myList.Add(item);
                item.Quantity = addedQuantity;
            }          
            
        }


        public bool Contains(Product item)
        {
            return myList.Contains(item);
        }
        public void StockAlert(Action<int, Product> stock)
        {
            stockLevel = stock;
        }

        public bool Remove(Product item, int quantityToRemove)
        {
            if (myList.Contains(item) && item.Quantity >= quantityToRemove)
            {
                if(item.Quantity == quantityToRemove)
                {
                    myList.Remove(item);
                }
                else
                {
                    item.Quantity -= quantityToRemove;
                }
                CheckStockLevel(item, quantityToRemove);
                return true;
            }
            return false;

        }


        private void CheckStockLevel(Product item, int removedQuantity)
        {

            int[] limits ={ 2, 5, 10 };
            var query = limits.FirstOrDefault(limit => limit < item.Quantity + removedQuantity && limit > item.Quantity);
            if (query != 0)
            {

                stockLevel(item.Quantity, item);
                
            }
        }

    }
}
