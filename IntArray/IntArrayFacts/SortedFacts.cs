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
            sortedArray.Add(5);
            sortedArray.Add(4);
            sortedArray.Add(1);
            sortedArray.Add(4);
            sortedArray.Add(32);
            sortedArray.Add(18);
            sortedArray.Add(0);
            Assert.Equal(4, sortedArray[2]);
        }
    }
}
