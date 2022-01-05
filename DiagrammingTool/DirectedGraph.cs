using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammingTool
{
    public class DirectedGraph
    {
        public Dictionary<string, Node> AllNodes = new Dictionary<string, Node>();

        public int Size => AllNodes.Count;

        public void AddNode(Node node)
            {
            if (node == null)
            {
                return;
            }

            if (AllNodes.ContainsKey(node.Name))
            {
                return;
            }

            AllNodes.Add(node.Name, node);
        }

        public void RemoveNode(Node node)
        {
            if (node == null)
            {
                return;
            }

            AllNodes.Remove(node.Name, out node);
        }

        public bool HasNode(Node node)
        {
            return AllNodes.Any(n => n.Value.Name == node.Name);
        }

        public Node GetNode(Node node)
        {
            return AllNodes.Values.First(n => n.Name.Equals(node.Name));
        }
    }
}
