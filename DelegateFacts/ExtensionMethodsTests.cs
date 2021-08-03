using System;
using Xunit;
using DelegateLinQ;
using System.Collections.Generic;

namespace ExtensionMethods
{
    public class ExtensionMethodsFacts
    {

        [Fact]
        public void ReturnTrueIfAllElementsAreRespectingCriteria()
        {
            int[] elements = { 1, 2, 3, 4, 5, 6 };
            bool result = ExtensionMethods.All(elements, e => e > -1);
            Assert.True(result);
        }

        [Fact]
        public void ReturnTrueIfAnyElementIsRespectingCriteria()
        {
            int[] elements = { 1, 2, 3, 4, 5, 6 };
            bool result = ExtensionMethods.Any(elements, e => e > -1);
            Assert.True(result);
        }

        [Fact]
        public void ReturnFirstElementThatIsRespectingCriteria()
        {
            int[] elements = { 1, 2, 3, 4, 5, 6 };
            int result = ExtensionMethods.First(elements, e => e > 5);
            Assert.Equal(6,result);
        }

        [Fact]
        public void ReturnSelectedElementsThatAreRespectingCriteria()
        {
            int[] elements = { 1, 2, 3, 4, 5, 6 };
            var newElements = elements.Select(e => e * e);
            int[] myarray = new int[6];
            int i = 0;
            foreach(var num in newElements)
            {
                myarray[i] = num;
                i++;
            }
            Assert.Equal(36, myarray[5]);
        }

        [Fact]
        public void ReturnManySelectedElementsThatAreRespectingCriteria()
        {
            int[][] arrays = {
                new[] {1, 2, 3},
                new[] {4},
                new[] {5, 6, 7, 8},
                new[] {12, 14}
            };
            IEnumerable<int> result = arrays.SelectMany(array => array);
            int[] myarray = new int[10];
            int i = 0;
            foreach (var num in result)
            {
                myarray[i] = num;
                i++;
            }
            Assert.Equal(6, myarray[5]);
        }

        [Fact]
        public void ReturnEnumerationThatAreRespectingTheCriteria()
        {
            List<string> fruits =
            new List<string> { "apple", "passionfruit", "banana", "mango",
                    "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);

            string[] myarray = new string[10];
            int i = 0;
            foreach (var num in query)
            {
                myarray[i] = num;
                i++;
            }
            Assert.Equal("grape", myarray[2]);
        }

        [Fact]
        public void ReturnDictionaryAfterReceivingparamtersForKeyAndValue()
        {
            List<string> list = new List<string>() { "cat", "dog", "animal" };
            int y = 1;
            var animals = list.ToDictionary(x => x, x => y++);
            Assert.True(animals.ContainsKey("cat"));
        }

        [Fact]
        public void ReturnResultEnumerationAfterReceivingTwoEnumerationsSelectors()
        {
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };
            var numbersAndWords = numbers.Zip(words, (first, second) => first + " " + second);
            string[] myarray = new string[10];
            int i = 0;
            foreach (var num in numbersAndWords)
            {
                myarray[i] = num;
                i++;
            }
            Assert.Equal("3 three", myarray[2]);

        }

        [Fact]
        public void ReturnTotalResultAfterAddingOnEnumeration()
        {
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };
            int numEven = ints.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total);
            Assert.Equal(6, numEven);
        }

        [Fact]
        public void JoinTwoEnumerationsShouldReturnSAmeKEyElements()
        {
            int[] intOne = { 4, 1, 2};
            int[] intTwo = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };
            var innerJoinResult = intTwo.Join(
                          intOne,
                          int1 => int1,
                          int2 => int2,
                          (int1, int2) => int1);
            int[] myarray = new int[10];
            int i = 0;
            foreach (var num in innerJoinResult)
            {
                myarray[i] = num;
                i++;
            }
            Assert.Equal(2, myarray[1]);
        }

    }
}
