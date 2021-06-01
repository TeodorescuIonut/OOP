using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public sealed class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get;  set; }

        public Node<T> Prev { get;  set; }
    }
}
