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
            sortedArray.Insert(7, 40);
            sortedArray[0] = 2;
            Assert.Equal(1, sortedArray[3]);
        }
    }
}
