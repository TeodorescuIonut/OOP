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
            Stock myStock = new Stock();
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
            myStock.Add(myproduct2);
            myStock.Add(myproduct);
            myStock.Add(myproduct2);
            myStock.Add(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct);
            myStock.CheckStockLevel((quantity, product) => Console.WriteLine(quantity + ":" + product));
        }
    }
}
