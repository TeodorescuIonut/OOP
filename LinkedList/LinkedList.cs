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
            Add(sentinel.Prev, newNode);
        }

        public void Add(Node<T> current, Node<T> newNode)
        {
            CheckForNull(current, nameof(current));
            CheckForNull(newNode, nameof(newNode));
            newNode.Next = current.Next;
            newNode.Prev = current;
            current.Next.Prev = newNode;
            current.Next = newNode;
            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            AddLast(newNode);
        }

        public void AddLast(Node<T> newNode)
        {
            CheckForNull(newNode, nameof(newNode));
            Add(sentinel.Prev, newNode);
        }

        public void AddFirst(T item)
        {
                Node<T> newNode = new Node<T>();
                newNode.Data = item;
                AddFirst(newNode);
        }

        public void AddFirst(Node<T> newNode)
        {
            CheckForNull(newNode, nameof(newNode));
            Add(sentinel, newNode);
        }

        public void AddAfter(Node<T> current, T item)
        {
            CheckForNull(current, nameof(current));
            Node<T> newNode = new Node<T>();
            newNode.Data = item;
            Add(current, newNode);
        }

        public void AddAfter(Node<T> current, Node<T> newNode)
        {
            CheckForNull(newNode, nameof(newNode));
            AddAfter(current, newNode.Data);
        }

        public void AddBefore(Node<T> current, T item)
        {
            CheckForNull(current, nameof(current));
            Node<T> beforeNode = new Node<T>();
            beforeNode.Data = item;
            Add(current.Prev, beforeNode);
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
            Node<T> temp = sentinel.Next;
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
            Node<T> temp = sentinel.Prev;
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

            Node<T> temp = sentinel.Next;
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
