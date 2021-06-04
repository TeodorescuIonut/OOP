using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CircularDoublyLinkedListCollection<T> : ICollection<T>
    {
        private Node<T> sentinel;

        public CircularDoublyLinkedListCollection()
        {
            sentinel = new Node<T>();
        }

        public int Count { get; protected set; }

        public Node<T> First
        {
            get { return sentinel; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            if (sentinel.Next == null)
            {
                sentinel = newNode;
                newNode.Next = sentinel;
                newNode.Prev = sentinel;
            }
            else
            {
                Node<T> last = sentinel.Prev;
                newNode.Next = sentinel;
                sentinel.Prev = newNode;
                newNode.Prev = last;
                last.Next = newNode;
            }

            Count++;
        }

        public void AddFirstItem(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            sentinel = newNode;
            sentinel.Next = sentinel;
            sentinel.Prev = sentinel;
        }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            if (sentinel.Next == null)
            {
                AddFirstItem(item);
            }
            else
            {
                Node<T> last = sentinel.Prev;
                newNode.Next = sentinel;
                newNode.Prev = last;
                last.Next = newNode;
                sentinel.Prev = newNode;
                sentinel = newNode;
            }

            Count++;
        }

        public void AddAfter(Node<T> current, T item)
        {
            if (current == null)
            {
                throw new ArgumentNullException(nameof(current));
            }

            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
            if (sentinel.Next == null)
            {
                AddFirstItem(item);
            }

            Count++;
        }

        public void AddBefore(Node<T> current, T item)
        {
            if (current == null)
            {
                throw new ArgumentNullException(nameof(current));
            }

            Node<T> temp = Find(current.Data);

            if (temp != current)
            {
                throw new InvalidOperationException("Node doesnt exist in the list");
            }

            if (sentinel.Next == null)
            {
                AddFirst(item);
            }
            else
            {
                Node<T> newNode = new Node<T>();
                newNode.Data = item;
                newNode.Prev = current.Prev;
                newNode.Next = current;
                current.Prev.Next = newNode;
                current.Prev = newNode;
                Count++;
            }
        }

        public void Clear()
        {
            sentinel = null;
            sentinel = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public Node<T> Find(T value)
        {
            Node<T> temp = sentinel;
            do
            {
                if (temp.Data.Equals(value))
                {
                    return temp;
                }

                temp = temp.Next;
            }
            while (temp != sentinel);
            return null;
        }

        public Node<T> FindLast(T value)
        {
            Node<T> temp = sentinel;
            do
            {
                if (temp.Data.Equals(value))
                {
                    return temp;
                }

                temp = temp.Prev;
            }
            while (temp != sentinel);
            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentException("Received a null argument!", nameof(array));
            }

            Node<T> temp = sentinel;
            do
            {
                array[arrayIndex] = temp.Data;
                arrayIndex++;
                temp = temp.Next;
            }
            while (temp != sentinel);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = sentinel;
            do
            {
                yield return temp.Data;
                temp = temp.Next;
            }
            while (temp != sentinel);
        }

        public bool Remove(T item)
            {
            Node<T> temp = Find(item);
            return RemoveNode(temp);
        }

        public bool RemoveNode(Node<T> nodeToRemove)
        {
            Node<T> previousNode;
            if (nodeToRemove == null)
            {
                return false;
            }

            previousNode = nodeToRemove.Prev;
            previousNode.Next = nodeToRemove.Next;
            nodeToRemove.Next.Prev = previousNode;
            if (sentinel == nodeToRemove)
            {
                sentinel = nodeToRemove.Next;
            }

            Count--;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void RemoveFirst()
            {
            if (sentinel == null)
            {
                return;
            }

            RemoveNode(sentinel);
        }

        public void RemoveLast()
        {
            if (sentinel == null)
            {
                return;
            }

            RemoveNode(sentinel.Prev);
        }

        public void PrintList()
        {
            Node<T> temp;
            temp = this.sentinel.Next;
            if (temp != null)
            {
                Console.Write("The list contains: ");
                do
                {
                    Console.Write(temp.Data + " ");
                    temp = temp.Next;
                }
                while (temp != this.sentinel.Next);

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }
    }
    }
