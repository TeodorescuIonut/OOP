using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammingTool
{
    public class Node
    {
        public readonly string Name;
        public Dictionary<string, Node> ChildNodes = new Dictionary<string, Node>();
        public List<string> Links = new List<string>();
        public string Id;
        internal bool Head;
        internal bool Tale;
        internal (int x, int y) Pos = (0, 0);

        public Node(string name)
        {
            Name = name;
            Id = name + new Random().Next(int.MinValue, int.MaxValue);
        }

        public Node AddNode(Node child, string text)
        {
            if (child == null)
            {
                return child;
            }

            ChildNodes.Add(child.Name, child);
            Links.Add(text);
            return this;
        }
    }
}
