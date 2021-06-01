using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CircularDoublyLinkedListCollection<T> : ICollection<T>
    {
        private Node<T> first;
        private Node<T> last;

        public CircularDoublyLinkedListCollection()
        {
        }

        public int Count { get; protected set; }

        public Node<T> First
        {
            get { return first; }
        }

        public Node<T> Last
        {
            get { return last; }
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
            if (first == null)
            {
                AddFirstItem(item);
            }
            else
            {
                last.Next = newNode;
                newNode.Next = first;
                newNode.Prev = last;
                last = newNode;
                first.Prev = last;
            }

            Count++;
        }

        public void AddFirstItem(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            first = newNode;
            last = first;
            first.Next = last;
            first.Prev = last;
        }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            if (first == null)
            {
                AddFirstItem(item);
            }
            else
            {
                first.Prev = newNode;
                newNode.Next = first;
                newNode.Prev = last;
                first = newNode;
                last.Next = first;
            }

            Count++;
        }

        public void AddAfter(Node<T> current, T item)
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

            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
            if (current == last)
            {
                last = newNode;
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

            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            newNode.Prev = current.Prev;
            newNode.Next = current;
            current.Prev.Next = newNode;
            current.Prev = newNode;
            if (current == first)
            {
                first = newNode;
            }

            Count++;
        }

        public void Clear()
        {
            first = null;
            first = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public Node<T> Find(T value)
        {
            Node<T> temp = first;
            do
            {
                if (temp.Data.Equals(value))
                {
                    return temp;
                }

                temp = temp.Next;
            }
            while (temp != first);
            return null;
        }

        public Node<T> FindLast(T value)
        {
            Node<T> temp = last;
            do
            {
                if (temp.Data.Equals(value))
                {
                    return temp;
                }

                temp = temp.Prev;
            }
            while (temp != last);
            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentException("Received a null argument!", nameof(array));
            }

            Node<T> temp = first;
            do
            {
                array[arrayIndex] = temp.Data;
                arrayIndex++;
                temp = temp.Next;
            }
            while (temp != first);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = first;
            do
            {
                yield return temp.Data;
                temp = temp.Next;
            }
            while (temp != first);
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
            nodeToRemove.Next.Prev = previousNode.Prev;
            if (first == nodeToRemove)
            {
                first = nodeToRemove.Next;
            }

            if (last == nodeToRemove)
            {
                last = nodeToRemove.Prev;
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
            if (first == null)
            {
                return;
            }

            RemoveNode(first);
        }

        public void RemoveLast()
        {
            if (last == null)
            {
                return;
            }

            RemoveNode(last);
        }

        public void PrintList()
        {
            Node<T> temp;
            temp = this.first;
            if (temp != null)
            {
                Console.Write("The list contains: ");
                do
                {
                    Console.Write(temp.Data + " ");
                    temp = temp.Next;
                }
                while (temp != this.first);

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }
    }
    }
