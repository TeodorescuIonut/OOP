using System;
using Xunit;
using Inventory;


namespace Inventory
{
    public class InventoryTest
    {
        [Fact]
        public void RemoveItemFromStockShourReturnNotification()
        {
            Stock<Product> myStock = new Stock<Product>();
            Product myproduct = new Product
            {
                Name = "jellyFish"
            };
            Product myproduct2 = new Product
            {
                Name = "swordfish"
            };
            myproduct.Name = "new";
            myStock.Add(myproduct);
            myStock.Add(myproduct2);
            myStock.Remove(myproduct2);
        }
    }
}
