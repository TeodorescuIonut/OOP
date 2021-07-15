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
            myDictionary[7] = "d";
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
            myDictionary.Add(2, "b");
            myDictionary.Add(7, "c");
            myDictionary.Add(12, "c");
            myDictionary.Remove(7);
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
            myDictionary.ContainsKey(2);
            myDictionary.Remove(7);
            myDictionary.Remove(1);
            foreach (KeyValuePair<int, string> entryValue in myDictionary)
            {
                Console.WriteLine(entryValue);
            }

            Assert.Empty(myDictionary);
        }

        [Fact]
        public void CopyCollectionShouldReturnCorrectNoOfCopiedElements()
        {
            var myDictionary = new MyDictionary<int, string>(5);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, "f");
            myDictionary.Add(7, "c");
            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[5];
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(3, "a");
            myDictionary.Add(item);
            myDictionary.CopyTo(array, 2);
            Assert.Equal(1, array[2].Key);
        }

        [Fact]
        public void CheckNoOfValuesShouldREturnCorrectNoOfElements()
        {
            var myDictionary = new MyDictionary<int, string>(4);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, "f");
            myDictionary.Add(7, "c");
            Assert.Equal(4, myDictionary.Values.Count);
        }

        [Fact]
        public void CheckIfContainsKeyValuePairShoulReturnTrue()
        {
            var myDictionary = new MyDictionary<int, string>(4);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(2, "b");
            bool result = myDictionary.Contains(item);
            Assert.True(result);
        }

        [Fact]
        public void CheckIfREmovedKeyValuePairShoulReturnTrue()
        {
            var myDictionary = new MyDictionary<int, string>(4);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(2, "b");
            bool result = myDictionary.Remove(item);
            Assert.True(result);
        }

        [Fact]
        public void CheckIfTRyGetValueReturnsIfItemExistsAndItsValue()
        {
            var myDictionary = new MyDictionary<int, string>(4);
            myDictionary[1] = "a";
            myDictionary.Add(2, "b");
            myDictionary.Add(10, null);
            myDictionary.Add(7, "c");
            string resultValue = " ";
            bool result = myDictionary.TryGetValue(7, out resultValue);
            Assert.True(result);
        }
    }
}
