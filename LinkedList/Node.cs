using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public sealed class Node<T>
    {
        public T Data;

        public Node(T data)
        {
            this.Data = data;
        }

        public Node<T> Next { get; internal set; }

        public Node<T> Prev { get; internal set; }

        public CircularDoublyLinkedListCollection<T> List { get; internal set; }
    }
}
