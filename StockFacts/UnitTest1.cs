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
            Product newProduct = new Product() { Name = "swordfish" };
            newProduct.Quantity = 2;
            myStock.Add(myproduct);
            myStock.Add(myproduct2);
            myStock.Add(myproduct2);
            myStock.Add(myproduct);
            myStock.Add(myproduct2);
            myStock.Add(myproduct2);
            myStock.StockAlert((quantity, product) => { newProduct.Quantity = quantity; newProduct = product; });
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct2);
            myStock.Remove(myproduct);
            Assert.True(myStock.result);
            Assert.Equal(1, newProduct.Quantity);
            Assert.Equal("jellyFish", newProduct.Name);
        }
    }
}
