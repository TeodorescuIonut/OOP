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
            bool test = false;
            myStock.Add(myproduct);
            myStock.Add(myproduct2);
            myStock.Add(myproduct2);
            myStock.Add(myproduct);
            myStock.Add(myproduct2);
            myStock.Add(myproduct2);
            myStock.StockAlert((quantity, product) => test = true);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct);
            Assert.True(test);
        }
    }
}
