using Arrays;
using System;
using Xunit;

namespace Arrays
{
    public class SortIntArrayFacts
    {
        [Fact]
        public void CheckIfElementCanBeAdded()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.AddInOrder(2);
            sortedArray.AddInOrder(5);
            sortedArray.AddInOrder(15);
            sortedArray.AddInOrder(2);
            sortedArray.AddInOrder(32);
            sortedArray.AddInOrder(18);          
            Assert.Equal(5, sortedArray[2]);
        }
    }
}
