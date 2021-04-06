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
            var newArray = new SortedIntArray();
            newArray.Add(2);
            newArray.Add(5);
            newArray.Add(15);
            newArray.Add(8);
            newArray.Add(32);
            newArray.Add(18);
            newArray.Sort();
            Assert.Equal(8, newArray[2]);
        }
    }
}
