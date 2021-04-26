using Arrays;
using System;
using Xunit;


namespace IntArrayFacts
{
    public class SortedListFacts
    {
        [Fact]
        public void CheckIfTElementCanBeAdded()
        {
            var sortedArray = new SortedList<string>();
            sortedArray.Add("Guru2");
            sortedArray.Add("Guru1");
            sortedArray.Add("Guru3");
            Assert.Equal("Guru2", sortedArray[1]);
        }
    }
}
