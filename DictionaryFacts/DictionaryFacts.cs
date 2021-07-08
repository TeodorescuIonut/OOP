namespace DictionaryFacts
{
    using System;
    using System.Collections.Generic;
    using Dictionary;
    using Xunit;

    public class DictionaryFacts
    {
        [Fact]
        public void AddItemShouldReturCorrectNo()
        {
            var myDictionary = new MyDictionary<int, string>(5);
            myDictionary.Add(1, "a");
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(3, "a");
            myDictionary.Add(item);
            Assert.Equal(5, myDictionary.Count);
        }

        [Fact]
        public void AddKeyValuePairShouldReturCorrectNo()
        {
            var myDictionary = new MyDictionary<int, string>(5);
            myDictionary.Add(1, "a");
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            myDictionary.Add(12, "c");
            Assert.Equal(5, myDictionary.Count);
        }

        [Fact]
        public void RemoveItemShouldReturCorrectPosition()
        {
            var myDictionary = new MyDictionary<int, string>(5);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            myDictionary.Add(12, "c");
            myDictionary.Remove(7);
            myDictionary.Remove(1);
            myDictionary.Add(17, "a");
            Assert.Equal("a", myDictionary[17]);
        }

        [Fact]
        public void ClearCollectionShouldReturnEmpty()
        {
            var myDictionary = new MyDictionary<int, string>(5);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            myDictionary.Add(12, "c");
            myDictionary.Clear();
            var count = myDictionary.Count;
            Assert.Equal(0, count);
        }

        [Fact]
        public void CopyCollectionShouldReturnCorrectNoOfCopiedElements()
        {
            var myDictionary = new MyDictionary<int, string>(5);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[5];
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(3, "a");
            myDictionary.Add(item);
            myDictionary.CopyTo(array, 2);
            Assert.Equal(10, array[2].Key);
        }

        [Fact]
        public void CheckNoOfValuesShouldREturnCorrectNoOfElements()
        {
            var myDictionary = new MyDictionary<int, string>(4);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            Assert.Equal(4, myDictionary.Values.Count);
        }
    }
}
