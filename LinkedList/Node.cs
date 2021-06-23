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

        internal Node<T> Next { get; set; }

        internal Node<T> Prev { get; set; }

        internal CircularDoublyLinkedListCollection<T> List { get; set; }
    }
}
