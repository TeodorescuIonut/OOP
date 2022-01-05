using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammingTool
{
    class Connection
    {
        internal string Arrow;

        public Connection(Node node, Node child, int nodeWidth)
        {
            const int markerWidth = 20;
            const int nodeHeight = 33 / 2;
            this.Arrow = $@"<defs>
    <marker id=""arrowhead"" markerWidth=""10"" markerHeight=""7"" 
    refX = ""0"" refY = ""3.5"" orient = ""auto"" >    
          <polygon points = ""0 0, 10 3.5, 0 7"" />     
         </marker>    
       </defs>   
       <line x1 = ""{node.Pos.x + nodeWidth}"" y1 = ""{node.Pos.y + nodeHeight}"" x2 = ""{child.Pos.x - markerWidth}"" y2 = ""{child.Pos.y + nodeHeight}"" stroke = ""#000""
  stroke-width = ""2""  marker-end = ""url(#arrowhead)"" /> ";
        }
    }
}
