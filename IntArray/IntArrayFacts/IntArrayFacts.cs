using Arrays;
using System;
using Xunit;

namespace IntArrayFacts
{
    public class IntArrayFacts
    {
        [Fact]
        public void CheckIfElementCanBeAdded()
        {
            var myArray = new IntArray();
            int number = 4;
            myArray.Add(number);
            Assert.Equal(1, myArray.Count());
        }

        [Fact]
        public void CheckValueofElement()
        {
            var myArray = new IntArray();
            int numberOne = 4;
            int numberTwo = 7;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            Assert.Equal(7, myArray.Element(1));
        }

        [Fact]
        public void SetValueOfElementGiven()
        {
            var myArray = new IntArray();
            int numberOne = 4;
            int numberTwo = 7;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            int numberThree = 6;
            myArray.SetElement(1, numberThree);
            Assert.Equal(6, myArray.Element(1));
        }
        [Fact]
        public void CheckIfContainsElement()
        {
            var myArray = new IntArray();
            int numberOne = 4;
            int numberTwo = 7;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            int numberThree = 4;
            Assert.True(myArray.Contains(numberThree));
        }

        [Fact]
        public void ReturnIndexOfElement()
        {
            var myArray = new IntArray();
            int numberOne = 4;
            int numberTwo = 7;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            Assert.Equal(1, myArray.IndexOf(numberTwo));
        }
        [Fact]
        public void InsertElementAtIndexGiven()
        {
            var myArray = new IntArray();
            int numberOne = 4;
            int numberTwo = 7;
            int numberThree = 12;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            myArray.Insert(1, numberThree);
            Assert.Equal(0, myArray.IndexOf(numberThree));
        }

        [Fact]
        public void ClearArrayReturnEmptyt()
        {
            var myArray = new IntArray();
            int numberOne = 4;
            int numberTwo = 7;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            myArray.Clear();
            Assert.Equal(0, myArray.Element(1));
        }

        [Fact]
        public void RemoveAnElement()
        {
            var myArray = new IntArray();
            int numberOne = 4;
            int numberTwo = 7;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            myArray.Remove(numberTwo);
            Assert.Equal(0, myArray.Element(1));
        }

        [Fact]
        public void RemoveAnElementAtPosition()
        {
            var myArray = new IntArray();
            int numberOne = 4;
            int numberTwo = 7;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            myArray.RemoveAt(1);
            Assert.Equal(0, myArray.Element(1));
        }
    }
}
