using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CircularDoublyLinkedListCollection<T> : ICollection<T>
    {
        private readonly Node<T> sentinel;

        public CircularDoublyLinkedListCollection()
        {
            sentinel = new Node<T>(default);
            sentinel.Next = sentinel;
            sentinel.Prev = sentinel;
        }

        public int Count { get; protected set; }

        public Node<T> First
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }

                return sentinel.Next;
            }
        }

        public Node<T> Last
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }

                return sentinel.Prev;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            AddAfter(sentinel.Prev, new Node<T>(item));
        }

        public void AddAfter(Node<T> current, Node<T> newNode)
        {
            CheckForNull(current, nameof(current));
            CheckForNull(newNode, nameof(newNode));
            newNode.Next = current.Next;
            newNode.Prev = current;
            current.Next.Prev = newNode;
            current.Next = newNode;
            Count++;
        }

        public void AddAfter(Node<T> current, T item)
        {
            AddAfter(current, new Node<T>(item));
        }

        public void AddLast(T item)
        {
            AddLast(new Node<T>(item));
        }

        public void AddLast(Node<T> newNode)
        {
            CheckForNull(newNode, nameof(newNode));
            AddBefore(sentinel, newNode);
        }

        public void AddFirst(T item)
        {
                AddFirst(new Node<T>(item));
        }

        public void AddFirst(Node<T> newNode)
        {
            CheckForNull(newNode, nameof(newNode));
            AddAfter(sentinel, newNode);
        }

        public void AddBefore(Node<T> current, T item)
        {
            CheckForNull(current, nameof(current));
            AddAfter(current.Prev, new Node<T>(item));
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            CheckForNull(newNode, nameof(newNode));
            AddBefore(node, newNode.Data);
        }

        public void CheckForNull(Node<T> current, string name)
            {
            if (current != null)
            {
                return;
            }

            throw new ArgumentNullException(name);
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
            for (Node<T> temp = sentinel.Next; temp != sentinel; temp = temp.Next)
            {
                if (temp.Data.Equals(value))
                {
                    return temp;
                }
            }

            return null;
        }

        public Node<T> FindLast(T value)
        {
            for (Node<T> temp = sentinel.Prev; temp != sentinel; temp = temp.Prev)
            {
                if (temp.Data.Equals(value))
                {
                    return temp;
                }
            }

            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentException("Received a null argument!", nameof(array));
            }

            for (Node<T> temp = sentinel.Next; temp != sentinel; temp = temp.Next)
            {
                array[arrayIndex] = temp.Data;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> temp = sentinel.Next; temp != sentinel; temp = temp.Next)
            {
                yield return temp.Data;
            }
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
            Count--;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void RemoveFirst()
            {
            RemoveNode(sentinel.Next);
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
