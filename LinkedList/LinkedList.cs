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
            sentinel.Next = sentinel;
            sentinel.Prev = sentinel;
        }

        public int Count { get; protected set; }

        public Node<T> Next
        {
            get { return sentinel.Next; }
        }

        public Node<T> Prev
        {
            get { return sentinel.Prev; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            sentinel = newNode;
            newNode.Next = sentinel;
            newNode.Prev = sentinel;
            Count++;
        }

        public void AddLast(T item)
        {
            if (Count == 0)
            {
                Add(item);
            }
            else
            {
                Node<T> lastItem = sentinel.Prev;
                AddAfter(lastItem, item);
            }
        }

        public void AddFirst(T item)
        {
            if (Count == 0)
            {
                Add(item);
            }
            else
            {
                Node<T> firstNode = sentinel;
                AddBefore(firstNode, item);
            }
        }

        public void AddAfter(Node<T> current, T item)
        {
            if (current == null)
            {
                throw new ArgumentNullException(nameof(current));
            }

            if (Count == 0)
            {
                Add(item);
            }
            else
            {
                Node<T> newNode = new Node<T>();
                newNode.Data = item;
                newNode.Next = current.Next;
                current.Next.Prev = newNode;
                newNode.Prev = current;
                current.Next = newNode;
                Count++;
            }
        }

        public void AddBefore(Node<T> current, T item)
        {
            if (current == null)
            {
                throw new ArgumentNullException(nameof(current));
            }

            if (Count == 0)
            {
                Add(item);
            }
            else
            {
                Node<T> newNode = new Node<T>();
                newNode.Data = item;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                newNode.Next = current;
                current.Prev = newNode;
                if (sentinel == current)
                {
                    sentinel = newNode;
                }

                Count++;
            }
        }

        public void AddAfterNode(Node<T> node, Node<T> newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            AddAfter(node, newNode.Data);
        }

        public void AddBeforeNode(Node<T> node, Node<T> newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            AddBefore(node, newNode.Data);
        }

        public void Clear()
        {
            sentinel.Next = null;
            sentinel.Prev = null;
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
    }
    }
