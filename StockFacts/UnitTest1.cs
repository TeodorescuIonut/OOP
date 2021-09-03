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
            myStock.Add(myproduct, 2);
            myStock.Add(myproduct2, 11);
            myStock.StockAlert((quantity, product) => test = true);
            myStock.Remove(myproduct2, 2);
            myStock.Remove(myproduct2, 2);
            myStock.Remove(myproduct2, 3);
            myStock.Remove(myproduct, 1);
            Assert.True(test);
        }
    }
}
