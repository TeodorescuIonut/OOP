using System;
using System.Collections.Generic;
using System.Text;


namespace Inventory
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        internal int lastLimit;
    }
}
