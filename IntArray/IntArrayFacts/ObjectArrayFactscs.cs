using Arrays;
using System;
using Xunit;


namespace IntArrayFacts
{
     public class ObjectArrayFactscs
    {
        [Fact]
        public void CheckIfIntegerCanBeAdded()
        {
            var integerArr = new ObjectArrayCollection
            {
                5,
                4,
                1,
                4,
                32,
                18,
                0
            };
            Assert.Equal(1, integerArr[2]);
        }
        [Fact]
        public void CheckIfContainsSpecificNumber()
        {
            var myArray = new ObjectArrayCollection();
            int numberOne = 4;
            string numberTwo = "7";
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            string numberThree = "7";
            foreach(var element in myArray)
            {
                Console.WriteLine(element);
            }
            Assert.True(myArray.Contains(numberThree));
        }

        [Fact]
        public void CheckIfStringtCanBeAdded()
        {
            var stringArr = new ObjectArrayCollection
            {
                "Jhon",
                "Mike"
            };
            Assert.Equal("Mike", stringArr[1]);
        }

        [Fact]
        public void InsertElementAtIndexGiven()
        {
            var myArray = new ObjectArrayCollection();
            int numberOne = 4;
            double numberTwo = 12.3;
            string numberThree = "12";
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            myArray.Insert(1, numberThree);
            Assert.Equal(1, myArray.IndexOf(numberThree));
        }
    }
}
