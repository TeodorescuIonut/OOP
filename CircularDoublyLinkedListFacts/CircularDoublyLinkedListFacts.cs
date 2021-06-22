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
            mylist.AddLast(numberFour);
            mylist.AddLast("Blue");
            mylist.AddLast("Eyes");
            mylist.AddLast("Eyes");
            Assert.Equal("Eyes", mylist.Last.Data);
        }

        [Fact]
        public void AddItemShouldReturnAddedItemOnTheFirstNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddLast(numberFour);
            mylist.AddLast("Blue");
            mylist.AddLast("Eyes");
            Assert.Equal("Eyes", mylist.Last.Data);
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
            mylist.AddFirst("Blue");
            mylist.AddFirst("Eyes");
            Node<string> currentNode;
            currentNode = mylist.Find("Eyes");
            mylist.AddAfter(currentNode, "the");
            Assert.Equal("the", currentNode.Next.Data);
        }

        [Fact]
        public void AddNodeShouldReturnAddedItemAfterNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.AddFirst("Blue");
            mylist.AddFirst("Eyes");
            Node<string> currentNode;
            currentNode = mylist.Find("Not");
            Node<string> newNode = new Node<string>("Red");
            mylist.AddAfter(currentNode, newNode);
            Assert.Equal("Red", currentNode.Next.Data);
        }

        [Fact]
        public void AddNodeShouldReturnAddedItemBeforeNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.AddFirst("Blue");
            mylist.AddFirst("Eyes");
            Node<string> currentNode;
            currentNode = mylist.Find("Eyes");
            Node<string> newNode = new Node<string>("Red");
            mylist.AddBefore(currentNode, newNode);
            Assert.Equal("Red", currentNode.Prev.Data);
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
            mylist.AddLast(numberFour);
            mylist.AddLast("Blue");
            mylist.AddLast("Eyes");
            bool result = mylist.Contains("Blue");
            Assert.True(result);
        }

        [Fact]
        public void FindIteminListShouldReturnNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "the";
            mylist.AddFirst(numberFour);
            mylist.AddFirst("Blue");
            mylist.AddFirst("Eyes");
            Node<string> foundNode = mylist.Find(numberFour);
            Assert.Equal("the", foundNode.Data);
        }

        [Fact]
        public void FindLastIteminListShouldReturnNode()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "Five";
            mylist.AddLast(numberFour);
            mylist.AddLast("the");
            mylist.AddLast("Blue");
            mylist.AddLast("the");
            mylist.AddLast("Eyes");
            Node<string> foundNode = mylist.FindLast("the");
            Assert.Equal("the", foundNode.Data);
        }

        [Fact]
        public void CopyArrayShouldReturnArrayOfNodes()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();  
            const string numberFour = "Five";
            mylist.AddLast(numberFour);
            mylist.AddLast("the");
            mylist.AddLast("Blue");
            mylist.AddLast("the");
            mylist.AddLast("Eyes");
            string[] myarray = new string[mylist.Count];
            mylist.CopyTo(myarray, 0);
            Assert.Equal(myarray[0], numberFour);
        }

        [Fact]
        public void RemoveFirstOcurrenceFromListShouldReturnTrue()
        {
            CircularDoublyLinkedListCollection<string> mylist = new CircularDoublyLinkedListCollection<string>();
            const string numberFour = "Five";
            mylist.AddFirst(numberFour);
            mylist.AddFirst("the");
            mylist.AddFirst("Blue");
            mylist.AddFirst("the");
            mylist.AddFirst("Eyes");
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
            mylist.AddFirst(numberFour);
            mylist.AddFirst("the");
            mylist.AddFirst("Blue");
            mylist.AddFirst("the");
            mylist.AddFirst("Eyes");
            mylist.RemoveLast();
            Assert.Equal("the", mylist.Last.Data);
        }

    }
}
