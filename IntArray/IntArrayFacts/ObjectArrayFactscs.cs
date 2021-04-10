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
            var integerArr = new ObjectArray();
            integerArr.Add(5);
            integerArr.Add(4);
            integerArr.Add(1);
            integerArr.Add(4);
            integerArr.Add(32);
            integerArr.Add(18);
            integerArr.Add(0);
            Assert.Equal(1, integerArr[2]);
        }
        [Fact]
        public void CheckIfContainsSpecificNumber()
        {
            var myArray = new ObjectArray();
            int numberOne = 4;
            string numberTwo = "7";
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            string numberThree = "7";
            Assert.True(myArray.Contains(numberThree));
        }

        [Fact]
        public void CheckIfStringtCanBeAdded()
        {
            var stringArr = new ObjectArray();
            stringArr.Add("Jhon");
            stringArr.Add("Mike");
            Assert.Equal("Mike", stringArr[1]);
        }

        [Fact]
        public void InsertElementAtIndexGiven()
        {
            var myArray = new ObjectArray();
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
