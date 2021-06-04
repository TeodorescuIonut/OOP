using LinkedList;
using System;
using Xunit;

namespace CircularDoublyLinkedListFacts
{
    public class CircularDoublyLinkedListFacts
    {
        [Fact]
        public void AddItemShouldReturnAddedItemOnTheLastNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.Add(numberFour);
            mylist.Add("Blue");
            mylist.Add("Eyes");
            mylist.Add("Eyes");
            Assert.Equal("the", mylist.First.Data);
        }

        [Fact]
        public void AddItemShouldReturnAddedItemOnTheFirstNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.AddFirst("Blue");
            mylist.AddFirst("Eyes");
            Assert.Equal("Eyes", mylist.First.Data);
        }

        [Fact]
        public void AddItemShouldReturnAddedItemBeforeNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.AddFirst("Blue");
            mylist.AddFirst("Eyes");
            mylist.AddFirst("Four");
            Node<string> currentNode;
            currentNode = mylist.Find("Eyes");
            mylist.AddBefore(currentNode, "Red");
            Assert.Equal("Red", currentNode.Prev.Data);
        }

        [Fact]
        public void AddItemShouldReturnAddedItemAfterNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.Add("Blue");
            mylist.Add("Eyes");
            Node<string> currentNode;
            currentNode = mylist.Find("Eyes");
            mylist.AddAfter(currentNode, "the");
            Assert.Equal("the", currentNode.Next.Data);
        }

        [Fact]
        public void ClearListShouldRetunrEmpty()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.Add("Blue");
            mylist.Add("Eyes");
            mylist.Clear();
            Assert.Null(mylist.First);
        }

        [Fact]
        public void CheckifContainsIteminListShouldReturnTrue()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.Add("Blue");
            mylist.Add("Eyes");
            bool result = mylist.Contains("Blue");
            Assert.True(result);
        }

        [Fact]
        public void FindIteminListShouldReturnNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.Add("Blue");
            mylist.Add("Eyes");
            Node<string> foundNode = mylist.Find(numberFour);
            Assert.Equal("the", foundNode.Data);
        }

        [Fact]
        public void FindLastIteminListShouldReturnNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "Five";
            mylist.Add(numberFour);
            mylist.Add("the");
            mylist.Add("Blue");
            mylist.Add("the");
            mylist.Add("Eyes");
            Node<string> foundNode = mylist.FindLast("the");
            Assert.Equal("the", foundNode.Data);
        }

        [Fact]
        public void CopyArrayShouldReturnArrayOfNodes()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();  
            const string numberFour = "Five";
            mylist.Add(numberFour);
            mylist.Add("the");
            mylist.Add("Blue");
            mylist.Add("the");
            mylist.Add("Eyes");
            string[] myarray = new string[mylist.Count];
            mylist.CopyTo(myarray, 0);
            Assert.Equal(myarray[0], numberFour);
        }

        [Fact]
        public void RemoveFirstOcurrenceFromListShouldReturnTrue()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "Five";
            mylist.Add(numberFour);
            mylist.Add("the");
            mylist.Add("Blue");
            mylist.Add("the");
            mylist.Add("Eyes");
            bool result = mylist.Remove("the");
            Assert.True(result);
        }

        [Fact]
        public void RemoveFirstElementFromListShouldReturnModifiedList()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "Five";
            mylist.Add(numberFour);
            mylist.Add("the");
            mylist.Add("Blue");
            mylist.Add("the");
            mylist.Add("Eyes");
            mylist.RemoveFirst();
            Assert.Equal("the", mylist.First.Data);
        }

        [Fact]
        public void RemoveLastElementFromListShouldReturnModifiedList()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "Five";
            mylist.Add(numberFour);
            mylist.Add("the");
            mylist.Add("Blue");
            mylist.Add("the");
            mylist.Add("Eyes");
            mylist.RemoveLast();
            Assert.Equal("the", mylist.First.Prev.Data);
        }

    }
}
