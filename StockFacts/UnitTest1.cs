using System;
using Xunit;
using Inventory;


namespace Inventory
{
    public class InventoryTest
    {

        [Fact]
        public void RemoveItemFromStockShouldReturnNotification()
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
            myStock.Add(myproduct);
            myStock.Add(myproduct2);
            myStock.Remove(myproduct2, (quantity,item) => Console.WriteLine(quantity + ":" + item));
        }
    }
}
