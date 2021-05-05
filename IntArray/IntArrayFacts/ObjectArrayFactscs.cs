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
            var integerArr = new List<int>()
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
            var myArray = new List<int>();
            int numberOne = 4;
            int numberTwo = 7;
            myArray.Add(numberOne);
            myArray.Add(numberTwo);
            int numberThree = 7;
            myArray.Add(numberThree);
            Assert.Equal(7, numberThree);
            myArray.Swap(ref numberOne, ref numberThree);
        }

        [Fact]
        public void CheckIfStringtCanBeAdded()
        {
            var stringArr = new List<string>()
            {
                "Jhon",
                "Mike"
            };
            Assert.Equal("Mike", stringArr[1]);
        }

        [Fact]
        public void InsertElementAtIndexGiven()
        {
            var myArray = new List<string>();
            string numberThree = "12";
            string numberFour = "15";
            string numberFive = "17";
            myArray.Add(numberThree);
            myArray.Add(numberFour);
            myArray.Add(numberFive);
            var enumerator = myArray.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
                
        }

        [Fact]
        public void ErrorIfReadingBeforeInitialized_CaptureExDemo()
        {
            var myArray = new List<string>();
            string numberThree = "12";
            string numberFour = "15";
            string numberFive = "17";
            myArray.Add(numberThree);
            myArray.Add(numberFour);
            myArray.Add(numberFive);
            string[] otherArray = null;

            var ex = Assert.Throws<ArgumentException>(() => myArray.CopyTo(otherArray, -1));

            Assert.Equal($"{nameof(myArray.CopyTo)} received a null argument!", ex.Message);
        }

    }
}
